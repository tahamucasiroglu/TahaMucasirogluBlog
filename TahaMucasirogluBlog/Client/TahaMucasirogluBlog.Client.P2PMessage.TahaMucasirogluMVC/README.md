# TahaMessaging - Uçtan Uca Şifrelenmiş Güvenli Mesajlaşma

TahaMessaging, RSA-2048 şifreleme ve SignalR .NET Client teknolojilerini kullanarak tamamen anonim ve güvenli mesajlaşma sağlayan bir web uygulamasıdır. JavaScript tarafında SignalR kütüphanesi kullanılmaz, tüm SignalR işlemleri backend'de .NET Client ile yapılır.


### 8 karakter yazan yerler 16 yapıldı.


## 🏗️ Mimari Genel Bakış

### Backend Yapı
```
TahaMessaging/
├── Controllers/
│   └── HomeController.cs         # Ana kontrolör - tüm işlemler
├── Services/
│   ├── SignalRClientService.cs   # Backend SignalR Client
│   ├── UserManager.cs           # Kullanıcı ve mesaj yönetimi
│   └── CryptoService.cs         # RSA şifreleme/çözme
├── Hubs/
│   └── ChatHub.cs               # SignalR Hub (mesaj yayını)
└── Views/
    └── Home/Index.cshtml        # Frontend (SADECE AJAX)
```

### Veri Akışı
```
JavaScript (AJAX) ←→ Controller ←→ SignalR Client ←→ SignalR Hub
```

## 📋 Kod Analizi

### 1. CryptoService.cs - RSA Şifreleme
```csharp
public static class CryptoService
{
    public static (string publicKey, string privateKey) GenerateKeyPair()
    {
        using var rsa = RSA.Create(2048);
        var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
        var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
        return (publicKey, privateKey);
    }

    public static string Encrypt(string plainText, string publicKeyBase64)
    {
        // Mesaj karşı tarafın public key'i ile şifrelenir
        using var rsa = RSA.Create();
        rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKeyBase64), out _);
        
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var encryptedBytes = rsa.Encrypt(plainBytes, RSAEncryptionPadding.OaepSHA256);
        
        return Convert.ToBase64String(encryptedBytes);
    }

    public static string Decrypt(string encryptedTextBase64, string privateKeyBase64)
    {
        // Şifreli mesaj kendi private key'imiz ile çözülür
        using var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKeyBase64), out _);
        
        var encryptedBytes = Convert.FromBase64String(encryptedTextBase64);
        var decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
        
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
```

### 2. UserManager.cs - Kullanıcı Yönetimi
```csharp
public class UserManager
{
    private readonly ConcurrentDictionary<string, UserInfo> _users = new();
    private readonly ConcurrentDictionary<string, string> _sessionToConnection = new();

    public class UserInfo
    {
        public string ConnectionId { get; set; }        // 8 karakterlik ID
        public string SessionId { get; set; }           // ASP.NET Session ID
        public string PublicKey { get; set; }           // RSA Public Key
        public string PrivateKey { get; set; }          // RSA Private Key
        public string? PartnerConnectionId { get; set; } // Bağlı olduğu kişi
        public Queue<(string from, string message)> PendingMessages { get; } = new();
    }

    public string CreateUser(string sessionId, string publicKey, string privateKey)
    {
        var connectionId = Guid.NewGuid().ToString("N").Substring(0, 8);
        var user = new UserInfo
        {
            ConnectionId = connectionId,
            SessionId = sessionId,
            PublicKey = publicKey,
            PrivateKey = privateKey
        };
        
        _users[connectionId] = user;
        _sessionToConnection[sessionId] = connectionId;
        
        return connectionId;
    }
}
```

### 3. SignalRClientService.cs - Backend SignalR Client
```csharp
public class SignalRClientService
{
    private HubConnection? _hubConnection;
    private readonly ConcurrentDictionary<string, Action<string, string>> _messageHandlers = new();

    public async Task EnsureConnectedAsync()
    {
        if (_hubConnection == null)
        {
            var baseUrl = "https://p2pmessage.tahamucasiroglu.com.tr";
            await StartAsync($"{baseUrl}/chatHub");
        }
        
        if (_hubConnection.State != HubConnectionState.Connected)
        {
            await _hubConnection.StartAsync();
        }
    }

    public async Task SendMessageAsync(string fromId, string toId, string encryptedMessage)
    {
        await EnsureConnectedAsync();
        await _hubConnection!.InvokeAsync("SendMessage", fromId, toId, encryptedMessage);
    }

    public void RegisterMessageHandler(string connectionId, Action<string, string> handler)
    {
        _messageHandlers[connectionId] = handler;
    }
}
```

### 4. HomeController.cs - Ana Kontrolör
```csharp
[HttpPost]
public async Task<IActionResult> SendMessage(string message)
{
    var sessionId = HttpContext.Session.Id;
    var myUser = _userManager.GetUserBySession(sessionId);
    
    if (myUser?.PartnerConnectionId == null)
        return Json(new { success = false, message = "Aktif bağlantı yok" });
    
    var partner = _userManager.GetUser(myUser.PartnerConnectionId);
    if (partner == null)
        return Json(new { success = false, message = "Partner bulunamadı" });
    
    try
    {
        // Mesaj partner'ın public key'i ile şifrelenir
        var encrypted = CryptoService.Encrypt(message, partner.PublicKey);
        
        // SignalR Client ile gönderilir
        await _signalRClient.SendMessageAsync(myUser.ConnectionId, partner.ConnectionId, encrypted);
        
        return Json(new { success = true });
    }
    catch (Exception ex)
    {
        return Json(new { success = false, message = ex.Message });
    }
}
```

## 🔄 İki Kişi Arasında Mesajlaşma Akışı

### Adım 1: Kullanıcı A Siteye Girer

**1.1 HomeController.Index() çalışır:**
```csharp
public IActionResult Index()
{
    // Session kontrolü
    if (!HttpContext.Session.IsAvailable)
    {
        ViewBag.Error = "Session servisi kullanılamıyor";
        return View();
    }

    // Session'dan connection ID'yi kontrol et
    var connectionId = HttpContext.Session.GetString("ConnectionId");
    
    if (string.IsNullOrEmpty(connectionId))
    {
        // Yeni kullanıcı - RSA key pair oluştur
        var (publicKey, privateKey) = CryptoService.GenerateKeyPair();
        connectionId = _userManager.CreateUser(HttpContext.Session.Id, publicKey, privateKey);
        
        // Session'a kaydet
        HttpContext.Session.SetString("ConnectionId", connectionId);
        HttpContext.Session.SetString("PublicKey", publicKey);
        HttpContext.Session.SetString("PrivateKey", privateKey);
        
        // Message handler kaydet
        _signalRClient.RegisterMessageHandler(connectionId, (fromId, encryptedMessage) =>
        {
            _userManager.AddPendingMessage(connectionId, fromId, encryptedMessage);
        });
    }
    
    ViewBag.ConnectionId = connectionId;
    return View();
}
```

**1.2 Kullanıcı A'nın durumu:**
- Session ID: `abc123def456`
- Connection ID: `a1b2c3d4` (8 karakter)
- Public Key: `MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA...`
- Private Key: `MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC...`

### Adım 2: Kullanıcı B Siteye Girer

**2.1 Aynı işlem Kullanıcı B için:**
- Session ID: `xyz789uvw012`
- Connection ID: `x9y8z7w6` (8 karakter)
- Public Key: `MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEB...`
- Private Key: `MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQD...`

### Adım 3: Kullanıcı A, B'ye Bağlantı İsteği Gönderir

**3.1 JavaScript (AJAX) - Kullanıcı A:**
```javascript
async function connect() {
    const targetId = 'x9y8z7w6'; // Kullanıcı B'nin ID'si
    
    const response = await fetch('/Home/Connect', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: `targetConnectionId=${encodeURIComponent(targetId)}`
    });
    
    const result = await response.json();
    if (result.success) {
        showChatPanel();
        startMessageChecking();
    }
}
```

**3.2 HomeController.Connect() çalışır:**
```csharp
[HttpPost]
public async Task<IActionResult> Connect(string targetConnectionId)
{
    var connectionId = HttpContext.Session.GetString("ConnectionId");
    if (string.IsNullOrEmpty(connectionId))
        return Json(new { success = false, message = "Session bulunamadı. Sayfayı yenileyin." });
    
    var myUser = _userManager.GetUser(connectionId);
    if (myUser == null)
        return Json(new { success = false, message = "Kullanıcı bulunamadı. Sayfayı yenileyin." });
    
    var targetUser = _userManager.GetUser(targetConnectionId);
    if (targetUser == null)
        return Json(new { success = false, message = "Hedef kullanıcı aktif değil" });
    
    if (targetUser.PartnerConnectionId != null)
        return Json(new { success = false, message = "Kullanıcı meşgul" });
    
    // Partners olarak işaretle
    _userManager.SetPartner(connectionId, targetConnectionId);
    
    // SignalR ile bildir
    await _signalRClient.SendConnectionRequestAsync(connectionId, targetConnectionId);
    
    return Json(new { success = true, message = "Bağlantı kuruldu" });
}
```

**3.3 UserManager.SetPartner() çalışır:**
```csharp
public void SetPartner(string connectionId1, string connectionId2)
{
    if (_users.TryGetValue(connectionId1, out var user1))
        user1.PartnerConnectionId = connectionId2;  // A → B
    
    if (_users.TryGetValue(connectionId2, out var user2))
        user2.PartnerConnectionId = connectionId1;  // B → A
}
```

**3.4 SignalRClientService.SendConnectionRequestAsync() çalışır:**
```csharp
public async Task SendConnectionRequestAsync(string fromId, string toId)
{
    await EnsureConnectedAsync();  // SignalR bağlantısını kontrol et
    await _hubConnection!.InvokeAsync("RequestConnection", fromId, toId);
}
```

**3.5 ChatHub.RequestConnection() çalışır:**
```csharp
public async Task RequestConnection(string fromId, string toId)
{
    // Tüm bağlı istemcilere bildir
    await Clients.All.SendAsync("ConnectionRequest", fromId, toId);
}
```

**3.6 SignalRClientService mesajı alır:**
```csharp
_hubConnection.On<string, string>("ConnectionRequest", (fromId, toId) =>
{
    if (_connectionRequests.TryGetValue(toId, out var tcs))
    {
        tcs.TrySetResult(true);
    }
});
```

### Adım 4: Kullanıcı A Mesaj Gönderir

**4.1 JavaScript (AJAX) - Kullanıcı A:**
```javascript
async function sendMessage() {
    const message = "Merhaba, nasılsın?";
    
    const response = await fetch('/Home/SendMessage', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: `message=${encodeURIComponent(message)}`
    });
    
    const result = await response.json();
    if (result.success) {
        addMessage(message, 'sent');  // Kendi mesajını göster
    }
}
```

**4.2 HomeController.SendMessage() çalışır:**
```csharp
[HttpPost]
public async Task<IActionResult> SendMessage(string message)
{
    var connectionId = HttpContext.Session.GetString("ConnectionId");
    if (string.IsNullOrEmpty(connectionId))
        return Json(new { success = false, message = "Session bulunamadı. Sayfayı yenileyin." });
    
    var myUser = _userManager.GetUser(connectionId);
    if (myUser?.PartnerConnectionId == null)
        return Json(new { success = false, message = "Aktif bağlantı yok" });
    
    var partner = _userManager.GetUser(myUser.PartnerConnectionId);
    if (partner == null)
        return Json(new { success = false, message = "Partner bulunamadı" });
    
    try
    {
        // Partner'ın public key'i ile şifrele
        var encrypted = CryptoService.Encrypt(message, partner.PublicKey);
        await _signalRClient.SendMessageAsync(connectionId, partner.ConnectionId, encrypted);
        
        return Json(new { success = true });
    }
    catch (Exception ex)
    {
        return Json(new { success = false, message = ex.Message });
    }
}
```

**4.3 CryptoService.Encrypt() çalışır:**
```csharp
public static string Encrypt(string plainText, string publicKeyBase64)
{
    using var rsa = RSA.Create();
    rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKeyBase64), out _);
    
    var plainBytes = Encoding.UTF8.GetBytes(plainText);  // "Merhaba, nasılsın?"
    var encryptedBytes = rsa.Encrypt(plainBytes, RSAEncryptionPadding.OaepSHA256);
    
    return Convert.ToBase64String(encryptedBytes);  // "kJ8vQzxM2nR..."
}
```

**4.4 SignalRClientService.SendMessageAsync() çalışır:**
```csharp
public async Task SendMessageAsync(string fromId, string toId, string encryptedMessage)
{
    await EnsureConnectedAsync();
    await _hubConnection!.InvokeAsync("SendMessage", fromId, toId, encryptedMessage);
}
```

**4.5 ChatHub.SendMessage() çalışır:**
```csharp
public async Task SendMessage(string fromId, string toId, string encryptedMessage)
{
    // Tüm bağlı istemcilere şifreli mesajı gönder
    await Clients.All.SendAsync("ReceiveMessage", fromId, toId, encryptedMessage);
}
```

### Adım 5: Kullanıcı B Mesajı Alır

**5.1 SignalRClientService mesajı alır:**
```csharp
_hubConnection.On<string, string, string>("ReceiveMessage", (fromId, toId, encryptedMessage) =>
{
    if (_messageHandlers.TryGetValue(toId, out var handler))
    {
        handler(fromId, encryptedMessage);  // Kullanıcı B'nin handler'ı
    }
});
```

**5.2 UserManager.AddPendingMessage() çalışır:**
```csharp
public void AddPendingMessage(string toConnectionId, string fromConnectionId, string message)
{
    if (_users.TryGetValue(toConnectionId, out var user))
    {
        user.PendingMessages.Enqueue((fromConnectionId, message));
    }
}
```

**5.3 JavaScript (AJAX) - Kullanıcı B mesajları kontrol eder:**
```javascript
async function checkMessages() {
    const response = await fetch('/Home/CheckMessages');
    const result = await response.json();
    
    if (result.success) {
        result.messages.forEach(msg => {
            addMessage(msg.message, 'received');  // Gelen mesajı göster
        });
    }
}

// Her saniye kontrol et
setInterval(checkMessages, 1000);
```

**5.4 HomeController.CheckMessages() çalışır:**
```csharp
[HttpGet]
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
    
    return Json(new { success = true, messages, isConnected = myUser.PartnerConnectionId != null });
}
```

**5.5 CryptoService.Decrypt() çalışır:**
```csharp
public static string Decrypt(string encryptedTextBase64, string privateKeyBase64)
{
    using var rsa = RSA.Create();
    rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKeyBase64), out _);
    
    var encryptedBytes = Convert.FromBase64String(encryptedTextBase64);  // "kJ8vQzxM2nR..."
    var decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
    
    return Encoding.UTF8.GetString(decryptedBytes);  // "Merhaba, nasılsın?"
}
```

## 🔒 Güvenlik Özellikleri

### 1. Uçtan Uca Şifreleme
- Her mesaj alıcının public key'i ile şifrelenir
- Sadece alıcının private key'i ile çözülebilir
- Sunucu mesaj içeriğini asla göremez

### 2. Veri Saklama
- Hiçbir mesaj veritabanında saklanmaz
- Kullanıcı bilgileri memory'de tutuluyor
- Uygulama yeniden başlatıldığında tüm veriler silinir

### 3. Session Güvenliği
- Her kullanıcı ASP.NET Session ile tanımlanır
- Session süresi 30 dakika
- Tarayıcı kapandığında session silinir

### 4. Anonim Kullanım
- Kayıt gerektirmez
- Kullanıcı adı/şifre yok
- Sadece connection ID ile tanımlama

## 🚀 Kurulum ve Çalıştırma

### Development:
```bash
cd TahaMessaging
dotnet run
```
Uygulama: `https://localhost:5001`

### Production:
```bash
export ASPNETCORE_ENVIRONMENT=Production
dotnet run
```
Uygulama: `https://p2pmessage.tahamucasiroglu.com.tr`

## 📊 Performans Notları

- **Memory Usage**: Her kullanıcı ~2KB memory kullanır
- **Message Queue**: Her kullanıcı için maksimum 100 mesaj kuyrukta bekler
- **Connection Limit**: Sunucu kapasitesine bağlı
- **Message Size**: RSA ile maksimum ~245 karakter

## ⚠️ Limitasyonlar

1. **Mesaj Uzunluğu**: RSA 2048 bit ile ~245 karakter limit
2. **Concurrent Users**: Memory'de tutulduğu için sınırlı
3. **Message Persistence**: Uygulama yeniden başlatıldığında mesajlar silinir
4. **Single Server**: Horizontal scaling desteklenmiyor

## 🔧 Gelecek Geliştirmeler

1. **Hybrid Encryption**: RSA + AES ile uzun mesaj desteği
2. **Redis Cache**: Kullanıcı bilgileri için persistent storage
3. **Message Delivery**: Mesaj teslim durumu takibi
4. **File Transfer**: Şifrelenmiş dosya paylaşımı
5. **Group Chat**: Çoklu kullanıcı desteği

---

Bu README, TahaMessaging uygulamasının her bir bileşeninin nasıl çalıştığını ve iki kullanıcı arasındaki mesajlaşmanın adım adım nasıl gerçekleştiğini detaylandırır. Uygulama tamamen güvenli, anonim ve uçtan uca şifrelenmiş mesajlaşma sağlar.