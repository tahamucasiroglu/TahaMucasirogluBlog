# TahaMucasirogluBlog.Domain.Models - Models Projesi Dokümantasyonu

## Proje Amacı

Bu proje, CV/özgeçmiş verilerini temsil eden model sınıflarını içerir. Entity'lerden farklı olarak, modeller domain katmanında veri transferi ve view model amaçlı kullanılırlar. Özellikle CV response'ları ve ilişkili veri yapıları için tasarlanmıştır.

## Proje Yapısı

```
TahaMucasirogluBlog.Domain.Models/
├── TahaMucasirogluBlog.Domain.Models.csproj
├── IModel.cs
├── Model.cs
├── Entity/
│   ├── GetExperienceTypeModel.cs
│   ├── GetExperienceWithTechnologyAndTypeModel.cs
│   ├── GetInfoModel.cs
│   ├── GetSkillWithSubSkillsModel.cs
│   ├── GetSocialLinkModel.cs
│   └── GetSubSkillModel.cs
└── Response/
    └── CvResponseModel.cs
```

## Base Interface ve Classes

### IModel Interface

Tüm modellerin uygulaması gereken temel interface.

```csharp
public interface IModel
{
    public Guid Id { get; set; }
}
```

### Model Abstract Class

Tüm model sınıfları için abstract base class.

```csharp
public abstract class Model : IModel
{
    public Guid Id { get; set; }
}
```

## Entity Model Sınıfları

### GetInfoModel.cs

Kişisel bilgileri temsil eden model.

```csharp
public class GetInfoModel : Model
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty; // Konum
    public string CoverLetter { get; set; } = string.Empty;
}
```

### GetSocialLinkModel.cs

Sosyal medya bağlantılarını temsil eden model.

```csharp
public class GetSocialLinkModel : Model
{
    public string Name { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;
    public string IconClass { get; init; } = string.Empty;
    public int DisplayOrder { get; init; } = 0;
    public bool IsVisible { get; init; } = true;
}
```

### GetSkillWithSubSkillsModel.cs

Yetenekleri ve alt yetenekleri içeren model.

```csharp
public class GetSkillWithSubSkillsModel : Model
{
    public string Name { get; set; } = default!;
    public List<GetSubSkillModel> SubSkills { get; set; } = new();
}
```

### GetSubSkillModel.cs

Alt yetenek bilgilerini temsil eden model.

```csharp
public class GetSubSkillModel : Model
{
    public Guid SkillId { get; set; }
    public string Name { get; set; } = default!; // ".NET", "Teamwork" vb.
}
```

### GetExperienceTypeModel.cs

Deneyim tiplerini temsil eden model.

```csharp
public class GetExperienceTypeModel : Model
{
    public string Name { get; set; } = string.Empty;
}
```

### GetExperienceWithTechnologyAndTypeModel.cs

İş deneyimlerini teknoloji ve tip bilgileri ile birlikte temsil eden model.

```csharp
public class GetExperienceWithTechnologyAndTypeModel : Model
{
    public string Title { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? Reference { get; set; }

    public GetExperienceTypeModel ExperienceType { get; set; } = default!;
    public List<GetSubSkillModel> SubSkills { get; set; } = new();
}
```

## Response Model Sınıfları

### CvResponseModel.cs

Tüm CV verilerini birleştiren ana response model.

```csharp
public class CvResponseModel : Model
{
    public GetInfoModel Info { get; set; } = default!;
    public List<GetSocialLinkModel> SocialLinks { get; set; } = new();
    public List<GetSkillWithSubSkillsModel> Skills { get; set; } = new();
    public List<GetExperienceWithTechnologyAndTypeModel> Experiences { get; set; } = new();
}
```

## Model Özellikleri

### 1. Basit ve Temiz Tasarım
- Minimal interface yapısı (sadece Id property'si)
- Abstract base class ile kod tekrarının önlenmesi
- Domain-focused model yapısı

### 2. CV/Özgeçmiş Odaklı
- Kişisel bilgiler (Info)
- Sosyal medya bağlantıları (SocialLinks)
- Yetenekler ve alt yetenekler (Skills/SubSkills)
- İş deneyimleri (Experiences)

### 3. Immutability Support
- `GetSocialLinkModel`'de `init` accessor'ları kullanımı
- Immutable properties ile data integrity

### 4. Nullable Reference Types
- Modern C# features kullanımı
- Null safety ile runtime error'ların önlenmesi
- Default value initialization

### 5. Navigation Properties
- Related entities arasında composition relationships
- Eager loading için ready yapı

## Project Configuration

### TahaMucasirogluBlog.Domain.Models.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  </PropertyGroup>
</Project>
```

**Özellikler:**
- **.NET 8.0** target framework
- **Implicit Usings** enabled
- **Nullable Reference Types** enabled
- **Treat Warnings as Errors** enabled (code quality için)

## Kullanım Senaryoları

### 1. Service Layer'da CV Data Aggregation

```csharp
public async Task<CvResponseModel> GetCvModelAsync()
{
    var cvModel = new CvResponseModel
    {
        Id = Guid.NewGuid(),
        Info = await GetInfoModelAsync(),
        SocialLinks = await GetSocialLinksModelAsync(),
        Skills = await GetSkillsModelAsync(),
        Experiences = await GetExperiencesModelAsync()
    };
    
    return cvModel;
}
```

### 2. Controller'da Model Response

```csharp
[HttpGet("cv")]
public async Task<ActionResult<CvResponseModel>> GetCv()
{
    var cvModel = await _cvService.GetCvModelAsync();
    return Ok(cvModel);
}
```

### 3. Client-Side Integration

```typescript
interface CvResponseModel {
    id: string;
    info: GetInfoModel;
    socialLinks: GetSocialLinkModel[];
    skills: GetSkillWithSubSkillsModel[];
    experiences: GetExperienceWithTechnologyAndTypeModel[];
}
```

## Mapping Strategy

Model'ler entity'ler veya DTO'lardan mapping ile oluşturulabilir:

```csharp
// Entity to Model mapping
CreateMap<Info, GetInfoModel>();
CreateMap<SocialLink, GetSocialLinkModel>();
CreateMap<Skill, GetSkillWithSubSkillsModel>()
    .ForMember(dest => dest.SubSkills, opt => opt.MapFrom(src => src.SubSkills));

// DTO to Model mapping
CreateMap<CvResponseDTO, CvResponseModel>();
CreateMap<GetInfoDTO, GetInfoModel>();
```

## Best Practices

### 1. Single Responsibility
- Her model belirli bir domain area'sına odaklanmış
- CV domain'i için specialized model'ler

### 2. Composition Over Inheritance
- Complex data structures için composition pattern
- Navigation properties ile ilişkili data access

### 3. Immutability Where Appropriate
- `GetSocialLinkModel`'de init-only properties
- Data integrity için immutable design

### 4. Defensive Programming
- Default value initialization
- Non-nullable reference types kullanımı
- Null-safe property access

### 5. Clean Architecture Compliance
- Domain katmanında pure model'ler
- Infrastructure dependencies yok
- Business logic odaklı tasarım

### 6. Performance Considerations
- Minimal property set
- Efficient collection initialization
- Memory-friendly design patterns

## Future Enhancements

Proje geliştirilirken eklenebilecek özellikler:

1. **Validation Attributes**: Model-level validation rules
2. **Display Attributes**: UI formatting için metadata
3. **Serialization Attributes**: JSON/XML serialization control
4. **Cache-Friendly Design**: Caching strategy için optimizasyon
5. **Audit Trail Support**: Created/Modified tracking
6. **Internationalization**: Multi-language support için model structure