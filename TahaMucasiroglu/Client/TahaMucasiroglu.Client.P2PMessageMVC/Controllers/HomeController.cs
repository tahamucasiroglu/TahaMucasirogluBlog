using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC.Services;

namespace TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager _userManager;
        private readonly SignalRClientService _signalRClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(UserManager userManager, SignalRClientService signalRClient, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signalRClient = signalRClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            // Session'� ba�lat
            if (!HttpContext.Session.IsAvailable)
            {
                ViewBag.Error = "Session servisi kullan�lam�yor";
                return View();
            }

            // Eski session varsa ve farkl� bir kullan�c� varsa onu temizle
            var oldConnectionId = HttpContext.Session.GetString("ConnectionId");
            if (!string.IsNullOrEmpty(oldConnectionId))
            {
                var oldUser = _userManager.GetUser(oldConnectionId);
                if (oldUser != null)
                {
                    // E�er partner'� varsa ona bildir
                    if (!string.IsNullOrEmpty(oldUser.PartnerConnectionId))
                    {
                        _ = Task.Run(async () =>
                        {
                            await _signalRClient.NotifyDisconnectionAsync(oldUser.PartnerConnectionId);
                        });
                    }
                    // Eski kullan�c�y� sil
                    _userManager.RemoveUser(oldUser.SessionId);
                    _signalRClient.UnregisterMessageHandler(oldConnectionId);
                }
            }

            // Session'� temizle
            HttpContext.Session.Clear();

            // Yeni kullan�c� - RSA key pair olu�tur
            var (publicKey, privateKey) = CryptoService.GenerateKeyPair();
            var connectionId = _userManager.CreateUser(HttpContext.Session.Id, publicKey, privateKey);

            // Session'a sadece bu sayfa i�in kaydet
            HttpContext.Session.SetString("ConnectionId", connectionId);
            HttpContext.Session.SetString("PublicKey", publicKey);
            HttpContext.Session.SetString("PrivateKey", privateKey);

            // Message handler kaydet
            _signalRClient.RegisterMessageHandler(connectionId, (messageType, data) =>
            {
                if (messageType == "CONNECTION_REQUEST")
                {
                    _userManager.AddPendingConnectionRequest(connectionId, data);
                }
                else if (messageType == "CONNECTION_ACCEPTED")
                {
                    _userManager.SetPartner(connectionId, data);
                    _userManager.AddPendingMessage(connectionId, "SYSTEM", "CONNECTION_ACCEPTED");
                }
                else if (messageType == "CONNECTION_REJECTED")
                {
                    _userManager.AddPendingMessage(connectionId, "SYSTEM", "CONNECTION_REJECTED");
                }
                else if (messageType == "USER_DISCONNECTED")
                {
                    _userManager.AddPendingMessage(connectionId, "SYSTEM", "USER_DISCONNECTED");
                }
                else
                {
                    _userManager.AddPendingMessage(connectionId, messageType, data);
                }
            });

            ViewBag.ConnectionId = connectionId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connect(string targetConnectionId)
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, message = "Session bulunamad�. Sayfay� yenileyin." });

            var myUser = _userManager.GetUser(connectionId);
            if (myUser == null)
                return Json(new { success = false, message = "Kullan�c� bulunamad�. Sayfay� yenileyin." });

            var targetUser = _userManager.GetUser(targetConnectionId);
            if (targetUser == null)
                return Json(new { success = false, message = "Hedef kullan�c� aktif de�il" });

            if (targetUser.PartnerConnectionId != null)
                return Json(new { success = false, message = "Kullan�c� me�gul" });

            // SignalR ile ba�lant� iste�i g�nder (hen�z partner olarak i�aretleme)
            await _signalRClient.SendConnectionRequestAsync(connectionId, targetConnectionId);

            return Json(new { success = true, message = "Ba�lant� iste�i g�nderildi, yan�t bekleniyor..." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptConnection(string requesterConnectionId)
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, message = "Session bulunamad�" });

            var myUser = _userManager.GetUser(connectionId);
            var requesterUser = _userManager.GetUser(requesterConnectionId);

            if (myUser == null || requesterUser == null)
                return Json(new { success = false, message = "Kullan�c� bulunamad�" });

            // �ki kullan�c�y� partner olarak i�aretle
            _userManager.SetPartner(connectionId, requesterConnectionId);

            // SignalR ile HER �K� TARAFA da ba�lant� kabul edildi bildir
            await _signalRClient.NotifyConnectionAcceptedAsync(connectionId, requesterConnectionId);

            // Pending request'i temizle
            _userManager.ClearPendingConnectionRequest(connectionId);

            return Json(new { success = true, message = "Ba�lant� kabul edildi" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectConnection(string requesterConnectionId)
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (!string.IsNullOrEmpty(connectionId))
            {
                _userManager.ClearPendingConnectionRequest(connectionId);
            }

            // SignalR ile ba�lant� reddedildi bildir
            await _signalRClient.NotifyConnectionRejectedAsync(requesterConnectionId);

            return Json(new { success = true, message = "Ba�lant� reddedildi" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(string message)
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, message = "Session bulunamad�. Sayfay� yenileyin." });

            var myUser = _userManager.GetUser(connectionId);
            if (myUser?.PartnerConnectionId == null)
                return Json(new { success = false, message = "Aktif ba�lant� yok" });

            var partner = _userManager.GetUser(myUser.PartnerConnectionId);
            if (partner == null)
                return Json(new { success = false, message = "Partner bulunamad�" });

            try
            {
                // Partner'�n public key'i ile �ifrele
                var encrypted = CryptoService.Encrypt(message, partner.PublicKey);
                await _signalRClient.SendMessageAsync(connectionId, partner.ConnectionId, encrypted);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult CheckMessages()
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, messages = new List<object>(), isConnected = false });

            var myUser = _userManager.GetUser(connectionId);
            if (myUser == null)
                return Json(new { success = false, messages = new List<object>(), isConnected = false });

            var messages = new List<object>();
            var privateKey = HttpContext.Session.GetString("PrivateKey");

            while (myUser.PendingMessages.Count > 0)
            {
                var (from, encrypted) = myUser.PendingMessages.Dequeue();
                try
                {
                    if (!string.IsNullOrEmpty(privateKey))
                    {
                        var decrypted = CryptoService.Decrypt(encrypted, privateKey);
                        messages.Add(new { from, message = decrypted });
                    }
                }
                catch
                {
                    // ��z�lemeyen mesaj
                }
            }

            return Json(new
            {
                success = true,
                messages,
                isConnected = myUser.PartnerConnectionId != null,
                connectionRequest = myUser.PendingConnectionRequest
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Disconnect()
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, message = "Session bulunamad�" });

            var myUser = _userManager.GetUser(connectionId);
            if (myUser?.PartnerConnectionId != null)
            {
                await _signalRClient.NotifyDisconnectionAsync(myUser.PartnerConnectionId);
                _userManager.SetPartner(connectionId, null!);
            }

            return Json(new { success = true });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
