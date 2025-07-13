# TahaMucasirogluBlog.Application.Managers - Manager Projesi Dokümantasyonu

## Proje Amacı

Bu proje, uygulamada kullanılan yönetici sınıflarını (manager) içerir. Manager'lar, cross-cutting concern'leri (kesişen kaygıları) yönetmek için kullanılır ve uygulama genelinde kullanılan ortak işlevleri sağlar.

## Proje Yapısı

```
TahaMucasirogluBlog.Application.Managers/
├── LoggerManager/
│   ├── ILoggerManager.cs
│   └── LoggerManager.cs
└── PasswordManager/
    ├── IPasswordManager.cs
    └── PasswordManager.cs
```

## Manager Sınıfları

### LoggerManager

Uygulama genelinde loglama işlemlerini yöneten manager.

#### ILoggerManager.cs
```csharp
public interface ILoggerManager
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
    void LogError(string message, Exception exception = null, params object[] args);
    void LogDebug(string message, params object[] args);
    void LogCritical(string message, Exception exception = null, params object[] args);
    void LogTrace(string message, params object[] args);
    
    // Structured logging
    void LogWithContext(LogLevel level, string message, object context);
    
    // Performance logging
    IDisposable BeginScope(string scopeName);
    void LogPerformance(string operationName, long elapsedMilliseconds);
}
```

#### LoggerManager.cs
```csharp
public class LoggerManager : ILoggerManager
{
    private readonly ILogger<LoggerManager> _logger;
    
    public LoggerManager(ILogger<LoggerManager> logger)
    {
        _logger = logger;
    }
    
    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }
    
    public void LogError(string message, Exception exception = null, params object[] args)
    {
        if (exception != null)
            _logger.LogError(exception, message, args);
        else
            _logger.LogError(message, args);
    }
    
    public void LogWithContext(LogLevel level, string message, object context)
    {
        using (_logger.BeginScope(context))
        {
            _logger.Log(level, message);
        }
    }
    
    public IDisposable BeginScope(string scopeName)
    {
        return _logger.BeginScope(new { Scope = scopeName, StartTime = DateTime.UtcNow });
    }
    
    public void LogPerformance(string operationName, long elapsedMilliseconds)
    {
        if (elapsedMilliseconds > 1000) // 1 saniyeden uzun süren işlemler
        {
            _logger.LogWarning("Performance: {OperationName} took {ElapsedMilliseconds}ms", 
                operationName, elapsedMilliseconds);
        }
        else
        {
            _logger.LogInformation("Performance: {OperationName} completed in {ElapsedMilliseconds}ms", 
                operationName, elapsedMilliseconds);
        }
    }
}
```

### PasswordManager

Şifre işlemlerini yöneten manager (hashing, verification, generation).

#### IPasswordManager.cs
```csharp
public interface IPasswordManager
{
    // Hashing
    string HashPassword(string password);
    string HashPassword(string password, PasswordHashType hashType);
    
    // Verification
    bool VerifyPassword(string password, string hashedPassword);
    bool VerifyPassword(string password, string hashedPassword, PasswordHashType hashType);
    
    // Password generation
    string GenerateRandomPassword(int length = 12);
    string GenerateRandomPassword(PasswordGenerationOptions options);
    
    // Password strength
    PasswordStrength CheckPasswordStrength(string password);
    bool IsPasswordValid(string password, PasswordPolicy policy);
    
    // Salt management
    string GenerateSalt();
    string HashPasswordWithSalt(string password, string salt);
}
```

#### PasswordManager.cs
```csharp
public class PasswordManager : IPasswordManager
{
    private readonly IConfiguration _configuration;
    private readonly PasswordHashType _defaultHashType;
    
    public PasswordManager(IConfiguration configuration)
    {
        _configuration = configuration;
        _defaultHashType = Enum.Parse<PasswordHashType>(
            _configuration["Security:DefaultHashType"] ?? "BCrypt");
    }
    
    public string HashPassword(string password)
    {
        return HashPassword(password, _defaultHashType);
    }
    
    public string HashPassword(string password, PasswordHashType hashType)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));
        
        return hashType switch
        {
            PasswordHashType.SHA256 => HashWithSHA256(password),
            PasswordHashType.SHA512 => HashWithSHA512(password),
            PasswordHashType.BCrypt => BCrypt.Net.BCrypt.HashPassword(password),
            PasswordHashType.Argon2 => HashWithArgon2(password),
            _ => throw new NotSupportedException($"Hash type {hashType} is not supported.")
        };
    }
    
    public bool VerifyPassword(string password, string hashedPassword)
    {
        // Hash tipini otomatik algıla
        if (hashedPassword.StartsWith("$2a$") || hashedPassword.StartsWith("$2b$"))
            return VerifyPassword(password, hashedPassword, PasswordHashType.BCrypt);
        
        if (hashedPassword.StartsWith("$argon2"))
            return VerifyPassword(password, hashedPassword, PasswordHashType.Argon2);
        
        // Diğer durumlar için default hash type kullan
        return VerifyPassword(password, hashedPassword, _defaultHashType);
    }
    
    public bool VerifyPassword(string password, string hashedPassword, PasswordHashType hashType)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            return false;
        
        try
        {
            return hashType switch
            {
                PasswordHashType.SHA256 => HashWithSHA256(password) == hashedPassword,
                PasswordHashType.SHA512 => HashWithSHA512(password) == hashedPassword,
                PasswordHashType.BCrypt => BCrypt.Net.BCrypt.Verify(password, hashedPassword),
                PasswordHashType.Argon2 => VerifyWithArgon2(password, hashedPassword),
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }
    
    public string GenerateRandomPassword(int length = 12)
    {
        var options = new PasswordGenerationOptions
        {
            Length = length,
            IncludeUppercase = true,
            IncludeLowercase = true,
            IncludeNumbers = true,
            IncludeSpecialCharacters = true
        };
        
        return GenerateRandomPassword(options);
    }
    
    public string GenerateRandomPassword(PasswordGenerationOptions options)
    {
        var chars = new StringBuilder();
        
        if (options.IncludeLowercase)
            chars.Append("abcdefghijklmnopqrstuvwxyz");
        if (options.IncludeUppercase)
            chars.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        if (options.IncludeNumbers)
            chars.Append("0123456789");
        if (options.IncludeSpecialCharacters)
            chars.Append("!@#$%^&*()_+-=[]{}|;:,.<>?");
        
        if (chars.Length == 0)
            throw new ArgumentException("At least one character type must be included.");
        
        var random = new Random();
        var password = new StringBuilder();
        
        for (int i = 0; i < options.Length; i++)
        {
            password.Append(chars[random.Next(chars.Length)]);
        }
        
        return password.ToString();
    }
    
    public PasswordStrength CheckPasswordStrength(string password)
    {
        if (string.IsNullOrEmpty(password))
            return PasswordStrength.VeryWeak;
        
        int score = 0;
        
        // Length check
        if (password.Length >= 8) score++;
        if (password.Length >= 12) score++;
        if (password.Length >= 16) score++;
        
        // Character variety
        if (Regex.IsMatch(password, @"[a-z]")) score++;
        if (Regex.IsMatch(password, @"[A-Z]")) score++;
        if (Regex.IsMatch(password, @"\d")) score++;
        if (Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]")) score++;
        
        // Common patterns (negative score)
        if (Regex.IsMatch(password, @"(.)\1{2,}")) score--; // Repeated characters
        if (Regex.IsMatch(password, @"(012|123|234|345|456|567|678|789|890)")) score--; // Sequential numbers
        if (Regex.IsMatch(password, @"(abc|bcd|cde|def|efg|fgh|ghi|hij|ijk|jkl|klm|lmn|mno|nop|opq|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz)", RegexOptions.IgnoreCase)) score--; // Sequential letters
        
        return score switch
        {
            >= 7 => PasswordStrength.VeryStrong,
            >= 5 => PasswordStrength.Strong,
            >= 3 => PasswordStrength.Medium,
            >= 1 => PasswordStrength.Weak,
            _ => PasswordStrength.VeryWeak
        };
    }
    
    public bool IsPasswordValid(string password, PasswordPolicy policy)
    {
        if (string.IsNullOrEmpty(password))
            return false;
        
        if (password.Length < policy.MinimumLength)
            return false;
        
        if (policy.RequireUppercase && !Regex.IsMatch(password, @"[A-Z]"))
            return false;
        
        if (policy.RequireLowercase && !Regex.IsMatch(password, @"[a-z]"))
            return false;
        
        if (policy.RequireNumbers && !Regex.IsMatch(password, @"\d"))
            return false;
        
        if (policy.RequireSpecialCharacters && !Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]"))
            return false;
        
        if (policy.MinimumStrength > PasswordStrength.None)
        {
            var strength = CheckPasswordStrength(password);
            if (strength < policy.MinimumStrength)
                return false;
        }
        
        return true;
    }
    
    // Private helper methods
    private string HashWithSHA256(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
    
    private string HashWithSHA512(string password)
    {
        using var sha512 = SHA512.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha512.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
    
    private string HashWithArgon2(string password)
    {
        // Argon2 implementation
        var salt = GenerateSalt();
        // ... Argon2 specific implementation
        return ""; // Placeholder
    }
    
    private bool VerifyWithArgon2(string password, string hashedPassword)
    {
        // Argon2 verification implementation
        return false; // Placeholder
    }
    
    public string GenerateSalt()
    {
        var saltBytes = new byte[16];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }
    
    public string HashPasswordWithSalt(string password, string salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var saltBytes = Convert.FromBase64String(salt);
        var combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
        
        Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);
        
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(combinedBytes);
        return Convert.ToBase64String(hash);
    }
}

// Supporting classes
public class PasswordGenerationOptions
{
    public int Length { get; set; } = 12;
    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSpecialCharacters { get; set; } = true;
}

public class PasswordPolicy
{
    public int MinimumLength { get; set; } = 8;
    public bool RequireUppercase { get; set; } = true;
    public bool RequireLowercase { get; set; } = true;
    public bool RequireNumbers { get; set; } = true;
    public bool RequireSpecialCharacters { get; set; } = false;
    public PasswordStrength MinimumStrength { get; set; } = PasswordStrength.Medium;
}

public enum PasswordStrength
{
    None = 0,
    VeryWeak = 1,
    Weak = 2,
    Medium = 3,
    Strong = 4,
    VeryStrong = 5
}
```

## Kullanım Örnekleri

### LoggerManager Kullanımı

```csharp
public class BlogPostService
{
    private readonly ILoggerManager _loggerManager;
    
    public async Task<BlogPost> GetByIdAsync(Guid id)
    {
        using (_loggerManager.BeginScope($"GetBlogPost-{id}"))
        {
            var stopwatch = Stopwatch.StartNew();
            
            try
            {
                _loggerManager.LogDebug("Blog yazısı getiriliyor. Id: {BlogPostId}", id);
                
                var blogPost = await _repository.GetByIdAsync(id);
                
                stopwatch.Stop();
                _loggerManager.LogPerformance("GetBlogPost", stopwatch.ElapsedMilliseconds);
                
                if (blogPost == null)
                {
                    _loggerManager.LogWarning("Blog yazısı bulunamadı. Id: {BlogPostId}", id);
                }
                
                return blogPost;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("Blog yazısı getirilirken hata oluştu.", ex, id);
                throw;
            }
        }
    }
}
```

### PasswordManager Kullanımı

```csharp
public class UserService
{
    private readonly IPasswordManager _passwordManager;
    
    public async Task<User> RegisterAsync(UserRegisterDTO dto)
    {
        // Password validation
        var policy = new PasswordPolicy
        {
            MinimumLength = 8,
            RequireUppercase = true,
            RequireLowercase = true,
            RequireNumbers = true,
            MinimumStrength = PasswordStrength.Medium
        };
        
        if (!_passwordManager.IsPasswordValid(dto.Password, policy))
            throw new ValidationException("Şifre güvenlik politikasına uygun değil.");
        
        // Password strength check
        var strength = _passwordManager.CheckPasswordStrength(dto.Password);
        if (strength < PasswordStrength.Medium)
            throw new ValidationException("Şifre yeterince güçlü değil.");
        
        // Hash password
        var hashedPassword = _passwordManager.HashPassword(dto.Password);
        
        var user = new User
        {
            Email = dto.Email,
            PasswordHash = hashedPassword,
            // ... other properties
        };
        
        return await _repository.AddAsync(user);
    }
    
    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _repository.GetByEmailAsync(email);
        if (user == null)
            return false;
        
        return _passwordManager.VerifyPassword(password, user.PasswordHash);
    }
    
    public string GenerateTemporaryPassword()
    {
        return _passwordManager.GenerateRandomPassword(16);
    }
}
```

## Best Practices

1. **Dependency Injection**: Manager'ları DI container'a kaydedin
2. **Interface Usage**: Her zaman interface üzerinden kullanın
3. **Configuration**: Ayarları appsettings.json'dan okuyun
4. **Error Handling**: Hataları uygun şekilde handle edin
5. **Performance**: Manager metodları performanslı olmalı
6. **Thread Safety**: Manager'lar thread-safe olmalı
7. **Testing**: Manager'lar için unit test yazın