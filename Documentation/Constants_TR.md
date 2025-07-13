# TahaMucasirogluBlog.Domain.Constant - Sabitler Projesi Dokümantasyonu

## Proje Amacı

Bu proje, uygulama genelinde kullanılan sabit değerleri (constants) merkezi bir yerde toplar. Bu sayede magic string/number kullanımı önlenir ve kod tutarlılığı sağlanır.

## Proje Yapısı

```
TahaMucasirogluBlog.Domain.Constant/
└── PasswordHashType.cs
```

## Mevcut Sabitler

### PasswordHashType.cs

Şifreleme algoritması tiplerini tanımlayan enum.

```csharp
public enum PasswordHashType
{
    SHA256 = 1,
    SHA512 = 2,
    MD5 = 3,
    BCrypt = 4,
    Argon2 = 5
}
```

**Kullanım Amacı**: Sistemde farklı şifreleme algoritmalarının kullanılabilmesi ve bunların tip güvenli bir şekilde yönetilmesi için kullanılır.

## Önerilebilecek Ek Sabitler

Proje büyüdükçe aşağıdaki sabit dosyaları eklenebilir:

### 1. SystemConstants.cs
```csharp
public static class SystemConstants
{
    public const string SystemName = "TahaMucasirogluBlog";
    public const string Version = "1.0.0";
    public const string DefaultLanguage = "tr-TR";
    public const string DefaultTimeZone = "Turkey Standard Time";
}
```

### 2. ValidationConstants.cs
```csharp
public static class ValidationConstants
{
    public const int TitleMaxLength = 200;
    public const int TitleMinLength = 3;
    public const int ContentMaxLength = 10000;
    public const int SummaryMaxLength = 500;
    public const int PasswordMinLength = 8;
    public const int PasswordMaxLength = 50;
    public const int UserNameMaxLength = 50;
}
```

### 3. CacheConstants.cs
```csharp
public static class CacheConstants
{
    public const string BlogPostCacheKey = "BlogPost_{0}";
    public const string CategoryListCacheKey = "Categories_All";
    public const string TagListCacheKey = "Tags_All";
    public const int DefaultCacheDuration = 3600; // seconds
    public const int ShortCacheDuration = 300; // 5 minutes
    public const int LongCacheDuration = 86400; // 24 hours
}
```

### 4. ApiConstants.cs
```csharp
public static class ApiConstants
{
    public const string ApiVersion = "v1";
    public const string ApiTitle = "TahaMucasirogluBlog API";
    public const string BearerScheme = "Bearer";
    public const int DefaultPageSize = 10;
    public const int MaxPageSize = 100;
}
```

### 5. RoleConstants.cs
```csharp
public static class RoleConstants
{
    public const string Admin = "Admin";
    public const string Author = "Author";
    public const string User = "User";
    public const string Guest = "Guest";
}
```

### 6. StatusConstants.cs
```csharp
public enum PostStatus
{
    Draft = 1,
    Published = 2,
    Archived = 3,
    Deleted = 4
}

public enum CommentStatus
{
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    Spam = 4
}
```

### 7. ErrorConstants.cs
```csharp
public static class ErrorConstants
{
    public const string NotFound = "Kayıt bulunamadı.";
    public const string Unauthorized = "Bu işlem için yetkiniz yok.";
    public const string InvalidInput = "Geçersiz giriş.";
    public const string ServerError = "Sunucu hatası oluştu.";
    
    public static class ValidationErrors
    {
        public const string RequiredField = "{0} alanı zorunludur.";
        public const string MaxLength = "{0} alanı en fazla {1} karakter olabilir.";
        public const string MinLength = "{0} alanı en az {1} karakter olmalıdır.";
        public const string InvalidEmail = "Geçersiz e-posta adresi.";
    }
}
```

### 8. RegexConstants.cs
```csharp
public static class RegexConstants
{
    public const string Email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public const string Slug = @"^[a-z0-9]+(?:-[a-z0-9]+)*$";
    public const string Phone = @"^(\+90|0)?[0-9]{10}$";
    public const string Url = @"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$";
}
```

## Kullanım Örnekleri

### Şifre Hashleme
```csharp
public string HashPassword(string password, PasswordHashType hashType)
{
    switch (hashType)
    {
        case PasswordHashType.SHA256:
            return HashWithSHA256(password);
        case PasswordHashType.BCrypt:
            return HashWithBCrypt(password);
        default:
            throw new NotSupportedException($"Hash type {hashType} is not supported.");
    }
}
```

### Validation Kullanımı
```csharp
public class BlogPostValidator : AbstractValidator<BlogPostAddDTO>
{
    public BlogPostValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(ValidationConstants.TitleMinLength)
            .MaximumLength(ValidationConstants.TitleMaxLength);
    }
}
```

### Cache Kullanımı
```csharp
public async Task<BlogPost> GetBlogPostAsync(Guid id)
{
    var cacheKey = string.Format(CacheConstants.BlogPostCacheKey, id);
    
    var cached = await _cache.GetAsync<BlogPost>(cacheKey);
    if (cached != null)
        return cached;
    
    var blogPost = await _repository.GetByIdAsync(id);
    await _cache.SetAsync(cacheKey, blogPost, CacheConstants.DefaultCacheDuration);
    
    return blogPost;
}
```

## Best Practices

1. **Naming Convention**: Sabit isimleri açık ve anlaşılır olmalı
2. **Grouping**: İlgili sabitler aynı sınıf içinde gruplanmalı
3. **Type Safety**: Mümkün olduğunda enum kullanın
4. **Documentation**: Her sabitin amacını XML comment ile belirtin
5. **No Magic Values**: Kod içinde magic string/number kullanmayın
6. **Centralization**: Tüm sabitler bu projede toplanmalı
7. **Immutability**: Sabitler değiştirilemez olmalı (const veya readonly)