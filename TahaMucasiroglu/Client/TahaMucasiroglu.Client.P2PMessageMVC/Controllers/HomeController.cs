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
            // Session'ý baþlat
            if (!HttpContext.Session.IsAvailable)
            {
                ViewBag.Error = "Session servisi kullanýlamýyor";
                return View();
            }

            // Eski session varsa ve farklý bir kullanýcý varsa onu temizle
            var oldConnectionId = HttpContext.Session.GetString("ConnectionId");
            if (!string.IsNullOrEmpty(oldConnectionId))
            {
                var oldUser = _userManager.GetUser(oldConnectionId);
                if (oldUser != null)
                {
                    // Eðer partner'ý varsa ona bildir
                    if (!string.IsNullOrEmpty(oldUser.PartnerConnectionId))
                    {
                        _ = Task.Run(async () =>
                        {
                            await _signalRClient.NotifyDisconnectionAsync(oldUser.PartnerConnectionId);
                        });
                    }
                    // Eski kullanýcýyý sil
                    _userManager.RemoveUser(oldUser.SessionId);
                    _signalRClient.UnregisterMessageHandler(oldConnectionId);
                }
            }

            // Session'ý temizle
            HttpContext.Session.Clear();

            // Yeni kullanýcý - RSA key pair oluþtur
            var (publicKey, privateKey) = CryptoService.GenerateKeyPair();
            var connectionId = _userManager.CreateUser(HttpContext.Session.Id, publicKey, privateKey);

            // Session'a sadece bu sayfa için kaydet
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
                return Json(new { success = false, message = "Session bulunamadý. Sayfayý yenileyin." });

            var myUser = _userManager.GetUser(connectionId);
            if (myUser == null)
                return Json(new { success = false, message = "Kullanýcý bulunamadý. Sayfayý yenileyin." });

            var targetUser = _userManager.GetUser(targetConnectionId);
            if (targetUser == null)
                return Json(new { success = false, message = "Hedef kullanýcý aktif deðil" });

            if (targetUser.PartnerConnectionId != null)
                return Json(new { success = false, message = "Kullanýcý meþgul" });

            // SignalR ile baðlantý isteði gönder (henüz partner olarak iþaretleme)
            await _signalRClient.SendConnectionRequestAsync(connectionId, targetConnectionId);

            return Json(new { success = true, message = "Baðlantý isteði gönderildi, yanýt bekleniyor..." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptConnection(string requesterConnectionId)
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, message = "Session bulunamadý" });

            var myUser = _userManager.GetUser(connectionId);
            var requesterUser = _userManager.GetUser(requesterConnectionId);

            if (myUser == null || requesterUser == null)
                return Json(new { success = false, message = "Kullanýcý bulunamadý" });

            // Ýki kullanýcýyý partner olarak iþaretle
            _userManager.SetPartner(connectionId, requesterConnectionId);

            // SignalR ile HER ÝKÝ TARAFA da baðlantý kabul edildi bildir
            await _signalRClient.NotifyConnectionAcceptedAsync(connectionId, requesterConnectionId);

            // Pending request'i temizle
            _userManager.ClearPendingConnectionRequest(connectionId);

            return Json(new { success = true, message = "Baðlantý kabul edildi" });
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

            // SignalR ile baðlantý reddedildi bildir
            await _signalRClient.NotifyConnectionRejectedAsync(requesterConnectionId);

            return Json(new { success = true, message = "Baðlantý reddedildi" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(string message)
        {
            var connectionId = HttpContext.Session.GetString("ConnectionId");
            if (string.IsNullOrEmpty(connectionId))
                return Json(new { success = false, message = "Session bulunamadý. Sayfayý yenileyin." });

            var myUser = _userManager.GetUser(connectionId);
            if (myUser?.PartnerConnectionId == null)
                return Json(new { success = false, message = "Aktif baðlantý yok" });

            var partner = _userManager.GetUser(myUser.PartnerConnectionId);
            if (partner == null)
                return Json(new { success = false, message = "Partner bulunamadý" });

            try
            {
                // Partner'ýn public key'i ile þifrele
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
                    // Çözülemeyen mesaj
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
                return Json(new { success = false, message = "Session bulunamadý" });

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
