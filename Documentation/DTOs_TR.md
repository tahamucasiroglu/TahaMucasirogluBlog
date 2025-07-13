# TahaMucasirogluBlog.Domain.DTOs - DTO Projesi Dokümantasyonu

## Proje Amacı

Bu proje, katmanlar arası veri transferi için kullanılan Data Transfer Object (DTO) sınıflarını içerir. DTO'lar, entity'lerin dış dünyaya açılması yerine, sadece gerekli verilerin taşınması için kullanılır.

## Proje Yapısı

```
TahaMucasirogluBlog.Domain.DTOs/
├── Abstract/
│   ├── IAddDTO.cs
│   ├── IDTO.cs
│   ├── IDeleteDTO.cs
│   ├── IGetDTO.cs
│   ├── IIdDTO.cs
│   ├── IRequestDTO.cs
│   ├── IResponseDTO.cs
│   └── IUpdateDTO.cs
├── Base/
│   ├── AddDTO.cs
│   ├── DTO.cs
│   ├── DeleteDTO.cs
│   ├── GetDTO.cs
│   ├── IdDTO.cs
│   ├── RequestDTO.cs
│   ├── ResponseDTO.cs
│   └── UpdateDTO.cs
└── Concrete/
    ├── Entity/
    │   ├── BlogPost/
    │   ├── BlogPostCategory/
    │   ├── BlogPostTag/
    │   ├── Category/
    │   ├── Comment/
    │   ├── Experience/
    │   ├── ExperienceTechnology/
    │   ├── ExperienceType/
    │   ├── Info/
    │   ├── Skill/
    │   ├── SocialLink/
    │   ├── SubSkill/
    │   ├── Tag/
    │   └── User/
    └── Response/
        └── CvResponseDTO.cs
```

## DTO Tipleri ve Amaçları

### Abstract Interface'ler

#### IDTO.cs
Tüm DTO'ların uygulaması gereken temel interface.

```csharp
public interface IDTO
{
    Guid IslemYapanKullaniciId { get; set; } // İşlemi yapan kullanıcı ID'si
}
```

#### IRequestDTO.cs / IResponseDTO.cs
Request ve Response DTO'larını ayırmak için kullanılan marker interface'ler.

```csharp
public interface IRequestDTO : IDTO
{
}

public interface IResponseDTO : IDTO
{
}
```

#### IAddDTO.cs / IUpdateDTO.cs / IGetDTO.cs / IDeleteDTO.cs
Farklı operasyon tipleri için interface'ler.

```csharp
public interface IAddDTO : IRequestDTO
{
}

public interface IUpdateDTO : IRequestDTO, IIdDTO
{
}

public interface IGetDTO : IResponseDTO, IIdDTO
{
    bool IsDeleted { get; set; }
    DateTime InsertedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
    Guid InsertedBy { get; set; }
    Guid? UpdatedBy { get; set; }
    Guid? DeletedBy { get; set; }
}

public interface IIdDTO : IDTO
{
    Guid Id { get; set; }
}
```

### Base Record Classes

Projede modern C# record syntax kullanılır.

#### DTO.cs
```csharp
public abstract record DTO : IDTO
{
    public Guid IslemYapanKullaniciId { get; set; }
}
```

#### AddDTO.cs
```csharp
public abstract record AddDTO : RequestDTO, IAddDTO
{
    // Add operasyonları için base record
}
```

#### GetDTO.cs
```csharp
public abstract record GetDTO : ResponseDTO, IGetDTO
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime InsertedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid InsertedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }
}
```

#### UpdateDTO.cs
```csharp
public abstract record UpdateDTO : RequestDTO, IUpdateDTO
{
    public Guid Id { get; set; }
}
```

## Concrete DTO Örnekleri

### BlogPost DTO'ları

#### AddBlogPostDTO
```csharp
public record AddBlogPostDTO : AddDTO
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int ViewCount { get; set; }
}
```

#### GetBlogPostDTO
```csharp
public record GetBlogPostDTO : GetDTO
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int ViewCount { get; set; }
}
```

#### UpdateBlogPostDTO
```csharp
public record UpdateBlogPostDTO : UpdateDTO
{
    public string Title { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int ViewCount { get; set; }
}
```

#### DeleteBlogPostDTO
```csharp
public record DeleteBlogPostDTO : DeleteDTO
{
    // Soft delete için base delete DTO yeterli
}
```

### User DTO'ları

#### AddUserDTO
```csharp
public record AddUserDTO : AddDTO
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
}
```

#### GetUserDTO
```csharp
public record GetUserDTO : GetDTO
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
}
```

### CV/Experience DTO'ları

#### GetExperienceWithTechnologyAndTypeDTO
```csharp
public record GetExperienceWithTechnologyAndTypeDTO : GetDTO
{
    public string CompanyName { get; set; } = default!;
    public string Position { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; } = default!;
    public GetExperienceTypeDTO ExperienceType { get; set; } = default!;
    public List<GetTechnologyDTO> Technologies { get; set; } = new();
}
```

#### GetSkillWithSubSkillsDTO
```csharp
public record GetSkillWithSubSkillsDTO : GetDTO
{
    public string Name { get; set; } = default!;
    public int Level { get; set; }
    public string Category { get; set; } = default!;
    public List<GetSubSkillDTO> SubSkills { get; set; } = new();
}
```

#### GetInfoDTO
```csharp
public record GetInfoDTO : GetDTO
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string CoverLetter { get; set; } = default!;
}
```

## Specialized Response DTOs

### CvResponseDTO.cs

CV API endpoint'i için özel response DTO.

```csharp
public record CvResponseDTO : ResponseDTO
{
    public GetInfoDTO Info { get; set; } = default!;
    public List<GetSocialLinkDTO> SocialLinks { get; set; } = default!;
    public List<GetSkillWithSubSkillsDTO> Skills { get; set; } = new();
    public List<GetExperienceWithTechnologyAndTypeDTO> Experiences { get; set; } = new();
}
```

## DTO Özellikleri

### 1. Record Syntax
- Modern C# record kullanımı
- Immutable properties
- Value-based equality
- Built-in ToString() implementation

### 2. Audit Trail Support
- GetDTO base class'ında full audit fields
- InsertedAt, UpdatedAt, DeletedAt tracking
- InsertedBy, UpdatedBy, DeletedBy user tracking
- IsDeleted soft delete support

### 3. Operation-Specific Design
- **AddDTO**: Yeni kayıt oluşturma (Id yok)
- **UpdateDTO**: Mevcut kayıt güncelleme (Id var)
- **GetDTO**: Veri okuma (audit fields ile)
- **DeleteDTO**: Soft delete işlemi

### 4. User Context
- Tüm DTO'larda IslemYapanKullaniciId property'si
- İşlemi yapan kullanıcının takibi

## DTO Kullanım Senaryoları

### 1. API Request/Response
```csharp
[HttpPost]
public async Task<IActionResult> CreateBlogPost(AddBlogPostDTO dto)
{
    // DTO validation ve business logic
    var result = await _blogPostService.AddAsync(dto);
    return Ok(result);
}
```

### 2. Service Layer
```csharp
public async Task<IReturn<GetBlogPostDTO>> GetByIdAsync(Guid id)
{
    var entity = await _repository.GetAsync(id);
    if (!entity.IsSuccess)
        return new ErrorReturn<GetBlogPostDTO>(entity.Message);
    
    var dto = _mapper.Map<GetBlogPostDTO>(entity.Data);
    return new SuccessReturn<GetBlogPostDTO>(dto);
}
```

### 3. Complex Data Aggregation
```csharp
public async Task<IReturn<CvResponseDTO>> GetCvAsync()
{
    var cvResponse = new CvResponseDTO
    {
        Info = await GetInfoAsync(),
        Skills = await GetSkillsWithSubSkillsAsync(),
        Experiences = await GetExperiencesWithTechnologyAndTypeAsync(),
        SocialLinks = await GetSocialLinksAsync()
    };
    
    return new SuccessReturn<CvResponseDTO>(cvResponse);
}
```

## Mapping Strategy

AutoMapper ile entity-DTO dönüşümleri:

```csharp
// Entity to DTO
CreateMap<BlogPost, GetBlogPostDTO>();
CreateMap<Experience, GetExperienceWithTechnologyAndTypeDTO>()
    .ForMember(dest => dest.ExperienceType, opt => opt.MapFrom(src => src.ExperienceType))
    .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.ExperienceTechnologies));

// DTO to Entity
CreateMap<AddBlogPostDTO, BlogPost>()
    .ForMember(dest => dest.Id, opt => opt.Ignore())
    .ForMember(dest => dest.InsertedAt, opt => opt.Ignore());
```

## Best Practices

1. **Operation-Specific DTOs**: Her operasyon için ayrı DTO kullanın
2. **Record Usage**: Immutability için C# record syntax
3. **Audit Fields**: GetDTO'larda full audit trail
4. **User Context**: İşlem yapan kullanıcı bilgisi
5. **Soft Delete Support**: IsDeleted field'ı
6. **Validation Ready**: FluentValidation için uygun yapı
7. **No Business Logic**: DTO'lar sadece veri taşımalı
8. **Consistent Naming**: Clear, descriptive naming convention