# TahaMucasirogluBlog.Presentation.API - Web API Projesi Dokümantasyonu

## Proje Amacı

Bu proje, RESTful API endpoint'lerini sağlayan presentation katmanıdır. Client uygulamalar, mobil uygulamalar ve external sistemler için HTTP tabanlı servisleri expose eder. Clean Architecture prensipleri doğrultusunda business logic'ten bağımsız olarak tasarlanmıştır.

## Proje Yapısı

```
TahaMucasirogluBlog.Presentation.API/
├── Attributes/
│   └── Attributes.cs
├── Controllers/
│   ├── Concrete/
│   │   ├── CvController.cs
│   │   └── Entity/
│   │       ├── BlogPostController.cs
│   │       ├── BlogPostCategoryController.cs
│   │       ├── BlogPostTagController.cs
│   │       ├── CategoryController.cs
│   │       ├── CommentController.cs
│   │       ├── ExperienceController.cs
│   │       ├── ExperienceTechnologyController.cs
│   │       ├── ExperienceTypeController.cs
│   │       ├── InfoController.cs
│   │       ├── SkillController.cs
│   │       ├── SocialLinkController.cs
│   │       ├── SubSkillController.cs
│   │       ├── TagController.cs
│   │       └── UserController.cs
├── Extensions/
│   ├── AuthenticationExtension.cs
│   ├── CorsExtension.cs
│   ├── DatabaseExtension.cs
│   ├── JsonExtension.cs
│   ├── LoggerExtension.cs
│   ├── MapperExtension.cs
│   ├── MiddlewaresExtension.cs
│   ├── RateLimiterExtension.cs
│   ├── ScopedExtension.cs
│   ├── SingletonExtension.cs
│   └── ValidationExtension.cs
├── Middlewares/
│   └── ErrorHandlingMiddleware.cs
├── Program.cs
├── Properties/
│   └── launchSettings.json
└── appsettings.json
```

## API Endpoint'leri

### 1. CvController (/api/Cv)

CV/Özgeçmiş verilerini sağlayan özel controller.

#### Endpoint'ler:
- **GET /api/Cv/Get** - CV verilerini service'den getirir
- **GET /api/Cv/GetTest** - Test amaçlı hardcoded CV verisi döndürür

```csharp
[ApiController]
[Route("api/[controller]")]
[LogConnection]
public class CvController : ControllerBase
{
    private readonly ICvService _cvService;
    
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        // CV service'den veri çeker ve döndürür
    }
    
    [HttpGet("GetTest")]
    public IActionResult GetTest()
    {
        // Hardcoded test verisi döndürür
    }
}
```

### 2. Entity Controller'ları

Tüm entity controller'ları generic base controller'dan inherit alır ve [Authorize] attribute'u gerektirir.

#### Ortak Endpoint'ler (Tüm Entity Controller'larda Mevcut):

- **GET /api/{Entity}/GetAll** - Tüm kayıtları getirir
- **GET /api/{Entity}/GetAllAsync** - Tüm kayıtları getirir (async)
- **GET /api/{Entity}/GetById** - ID'ye göre kayıt getirir
- **GET /api/{Entity}/GetByIdAsync** - ID'ye göre kayıt getirir (async)
- **GET /api/{Entity}/HealthCheck** - Sistem health check
- **POST /api/{Entity}/HealthCheck** - Sistem health check (hesaplama ile)
- **POST /api/{Entity}/Add** - Yeni kayıt ekler
- **POST /api/{Entity}/AddAsync** - Yeni kayıt ekler (async)
- **POST /api/{Entity}/Update** - Mevcut kaydı günceller
- **POST /api/{Entity}/UpdateAsync** - Mevcut kaydı günceller (async)
- **POST /api/{Entity}/Delete** - Kayıt siler
- **POST /api/{Entity}/DeleteAsync** - Kayıt siler (async)

#### Entity Controller'ları:

1. **BlogPostController** (/api/BlogPost) - Blog yazıları
2. **BlogPostCategoryController** (/api/BlogPostCategory) - Blog-kategori ilişkileri
3. **BlogPostTagController** (/api/BlogPostTag) - Blog-etiket ilişkileri
4. **CategoryController** (/api/Category) - Kategoriler
5. **CommentController** (/api/Comment) - Yorumlar
6. **ExperienceController** (/api/Experience) - İş deneyimleri
7. **ExperienceTechnologyController** (/api/ExperienceTechnology) - Deneyim-teknoloji ilişkileri
8. **ExperienceTypeController** (/api/ExperienceType) - Deneyim tipleri
9. **InfoController** (/api/Info) - Kişisel bilgiler
10. **SkillController** (/api/Skill) - Yetenekler
11. **SocialLinkController** (/api/SocialLink) - Sosyal medya bağlantıları
12. **SubSkillController** (/api/SubSkill) - Alt yetenekler
13. **TagController** (/api/Tag) - Etiketler
14. **UserController** (/api/User) - Kullanıcılar

### Generic Base Controller Pattern

Tüm entity controller'ları aşağıdaki pattern'i takip eder:

```csharp
[Authorize]
[ApiController]
[Route("api/[controller]")]
[LogConnection]
public class BlogPostController : ControllerBase
{
    // Generic CRUD operations provided by base controller
    // Entity-specific operations can be added here
}
```

## Güvenlik ve Authorization

### Authorization
- **CvController**: Public access (authorization gerekmez)
- **Tüm Entity Controller'ları**: [Authorize] attribute gerektirir

### Logging
- Tüm controller'larda **LogConnection** attribute'u kullanılır
- Request/response loglama yapılır

## Data Transfer Objects (DTOs)

API'de kullanılan ana DTO'lar:

### CV Response DTO
```csharp
public record CvResponseDTO : ResponseDTO
{
    public GetInfoDTO Info { get; set; } = default!;
    public List<GetSocialLinkDTO> SocialLinks { get; set; } = default!;
    public List<GetSkillWithSubSkillsDTO> Skills { get; set; } = new();
    public List<GetExperienceWithTechnologyAndTypeDTO> Experiences { get; set; } = new();
}
```

### Base DTO Hierarchy
- **DTO** - Base abstract record
- **AddDTO** - Ekleme işlemleri için
- **GetDTO** - Okuma işlemleri için (audit fields ile)
- **UpdateDTO** - Güncelleme işlemleri için
- **DeleteDTO** - Silme işlemleri için
- **RequestDTO/ResponseDTO** - API request/response'ları için

## Error Handling

### Return Type System
API, exception fırlatmak yerine custom IReturn<T> sistemi kullanır:

```csharp
public interface IReturn<T>
{
    bool IsSuccess { get; }
    string Message { get; }
    T Data { get; }
}
```

### Error Middleware
```csharp
public class ErrorHandlingMiddleware
{
    // Global exception handling
    // Custom error responses
    // Logging integration
}
```

## Audit Trail

Tüm entity'lerde audit trail özellikleri:

```csharp
public interface IEntity
{
    Guid Id { get; set; }
    bool IsDeleted { get; set; }
    DateTime InsertedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
    Guid InsertedBy { get; set; }
    Guid? UpdatedBy { get; set; }
    Guid? DeletedBy { get; set; }
}
```

## API Configuration Features

### Extension Methods
- **AuthenticationExtension** - JWT authentication setup
- **CorsExtension** - CORS policy configuration
- **DatabaseExtension** - Entity Framework configuration
- **LoggerExtension** - Serilog integration
- **ValidationExtension** - FluentValidation setup

### Middleware Pipeline
1. Authentication/Authorization
2. Error Handling
3. Logging
4. CORS
5. Rate Limiting (opsiyonel)

## API Test Endpoints

### Health Check
Tüm entity controller'larda health check endpoint'leri mevcut:
- **GET /api/{Entity}/HealthCheck** - Basit health check
- **POST /api/{Entity}/HealthCheck** - Hesaplama ile health check

### Test Data
**GET /api/Cv/GetTest** - Test amaçlı hardcoded CV verisi

## Best Practices

1. **Generic Pattern**: Kod tekrarını önlemek için generic base controller
2. **Consistent API Structure**: Tüm entity'ler için aynı endpoint pattern
3. **Authorization**: Entity işlemleri için authorization gerekli
4. **Soft Delete**: Fiziksel silme yerine soft delete
5. **Audit Trail**: Tüm işlemlerde kullanıcı ve zaman takibi
6. **Structured Logging**: LogConnection attribute ile detaylı loglama
7. **Error Handling**: Custom return types ile consistent error handling
8. **Async Operations**: Performans için async/await pattern