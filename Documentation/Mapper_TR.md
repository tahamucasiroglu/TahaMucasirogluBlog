# TahaMucasirogluBlog.Application.Mapper - Mapper Projesi Dokümantasyonu

## Proje Amacı

Bu proje, AutoMapper kütüphanesini kullanarak entity'ler ile DTO'lar arasındaki dönüşümleri yöneten mapping profile'larını içerir. Object-to-object mapping işlemlerini merkezi bir yerde toplar ve kod tekrarını önler.

## Proje Yapısı

```
TahaMucasirogluBlog.Application.Mapper/
├── Extensions/
│   └── ConfigExtension/
│       └── ConfigExtension.cs
└── MapProfile/
    ├── Entity/
    │   ├── BlogPostCategoryMapProfile.cs
    │   ├── BlogPostMapProfile.cs
    │   ├── BlogPostTagMapProfile.cs
    │   ├── CategoryMapProfile.cs
    │   ├── CommentMapProfile.cs
    │   ├── ExperienceMapProfile.cs
    │   ├── ExperienceTechnologyMapProfile.cs
    │   ├── ExperienceTypeMapProfile.cs
    │   ├── InfoMapProfile.cs
    │   ├── SkillMapProfile.cs
    │   ├── SocialLinkMapProfile.cs
    │   ├── SubSkillMapProfile.cs
    │   ├── TagMapProfile.cs
    │   └── UserMapProfile.cs
    └── Response/
        └── CvResponseDTOMappingProfile.cs
```

## Temel Bileşenler

### Extensions/ConfigExtension.cs

AutoMapper configuration için extension metodlar.

```csharp
public static class ConfigExtension
{
    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(typeof(ConfigExtension).Assembly);
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;
        });
        
        return services;
    }
    
    public static void ValidateMapperConfiguration(this IServiceProvider serviceProvider)
    {
        var mapper = serviceProvider.GetRequiredService<IMapper>();
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
```

## Entity Mapping Profilleri

### BlogPostMapProfile.cs

Blog yazıları için mapping tanımlamaları.

```csharp
public class BlogPostMapProfile : Profile
{
    public BlogPostMapProfile()
    {
        // Entity to DTO
        CreateMap<BlogPost, BlogPostGetDTO>()
            .ForMember(dest => dest.AuthorName, 
                opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.AuthorEmail, 
                opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.Categories, 
                opt => opt.MapFrom(src => src.BlogPostCategories.Select(bc => bc.Category)))
            .ForMember(dest => dest.Tags, 
                opt => opt.MapFrom(src => src.BlogPostTags.Select(bt => bt.Tag)))
            .ForMember(dest => dest.CommentCount, 
                opt => opt.MapFrom(src => src.Comments.Count(c => c.IsApproved)))
            .ForMember(dest => dest.ReadingTime, 
                opt => opt.MapFrom(src => CalculateReadingTime(src.Content)));
        
        // DTO to Entity (Add)
        CreateMap<BlogPostAddDTO, BlogPost>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.Slug, 
                opt => opt.MapFrom(src => src.Title.ToSlug()))
            .ForMember(dest => dest.BlogPostCategories, opt => opt.Ignore())
            .ForMember(dest => dest.BlogPostTags, opt => opt.Ignore())
            .AfterMap((src, dest, context) =>
            {
                // Categories mapping
                if (src.CategoryIds != null && src.CategoryIds.Any())
                {
                    dest.BlogPostCategories = src.CategoryIds
                        .Select(categoryId => new BlogPostCategory
                        {
                            BlogPostId = dest.Id,
                            CategoryId = categoryId
                        }).ToList();
                }
                
                // Tags mapping
                if (src.TagIds != null && src.TagIds.Any())
                {
                    dest.BlogPostTags = src.TagIds
                        .Select(tagId => new BlogPostTag
                        {
                            BlogPostId = dest.Id,
                            TagId = tagId
                        }).ToList();
                }
            });
        
        // DTO to Entity (Update)
        CreateMap<BlogPostUpdateDTO, BlogPost>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Slug, 
                opt => opt.MapFrom(src => src.Title.ToSlug()))
            .ForAllOtherMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
    
    private static int CalculateReadingTime(string content)
    {
        if (string.IsNullOrEmpty(content))
            return 0;
        
        var wordsPerMinute = 200;
        var wordCount = content.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        var readingTime = (int)Math.Ceiling((double)wordCount / wordsPerMinute);
        
        return Math.Max(1, readingTime); // En az 1 dakika
    }
}
```

### CategoryMapProfile.cs

Kategori mapping tanımlamaları.

```csharp
public class CategoryMapProfile : Profile
{
    public CategoryMapProfile()
    {
        CreateMap<Category, CategoryGetDTO>()
            .ForMember(dest => dest.PostCount, 
                opt => opt.MapFrom(src => src.BlogPostCategories.Count))
            .ForMember(dest => dest.ParentCategoryName, 
                opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Name : null))
            .ForMember(dest => dest.SubCategories, 
                opt => opt.MapFrom(src => src.SubCategories));
        
        CreateMap<CategoryAddDTO, Category>()
            .ForMember(dest => dest.Slug, 
                opt => opt.MapFrom(src => src.Name.ToSlug()));
        
        CreateMap<CategoryUpdateDTO, Category>()
            .ForMember(dest => dest.Slug, 
                opt => opt.MapFrom(src => src.Name.ToSlug()))
            .ForAllOtherMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
```

### UserMapProfile.cs

Kullanıcı mapping tanımlamaları.

```csharp
public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<User, UserGetDTO>()
            .ForMember(dest => dest.FullName, 
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.PostCount, 
                opt => opt.MapFrom(src => src.BlogPosts.Count))
            .ForMember(dest => dest.Password, opt => opt.Ignore()) // Şifre asla DTO'da olmamalı
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        
        CreateMap<UserRegisterDTO, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // PasswordManager ile set edilecek
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        
        CreateMap<UserUpdateDTO, User>()
            .ForMember(dest => dest.Email, opt => opt.Ignore()) // Email güncellenmemeli
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForAllOtherMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
```

### ExperienceMapProfile.cs

Deneyim mapping tanımlamaları (CV için).

```csharp
public class ExperienceMapProfile : Profile
{
    public ExperienceMapProfile()
    {
        CreateMap<Experience, ExperienceGetDTO>()
            .ForMember(dest => dest.Duration, 
                opt => opt.MapFrom(src => CalculateDuration(src.StartDate, src.EndDate)))
            .ForMember(dest => dest.IsCurrent, 
                opt => opt.MapFrom(src => !src.EndDate.HasValue))
            .ForMember(dest => dest.Technologies, 
                opt => opt.MapFrom(src => src.ExperienceTechnologies.Select(et => et.Technology.Name)));
        
        CreateMap<Experience, GetExperienceWithTechnologyAndTypeModel>()
            .ForMember(dest => dest.ExperienceType, 
                opt => opt.MapFrom(src => src.ExperienceType))
            .ForMember(dest => dest.Technologies, 
                opt => opt.MapFrom(src => src.ExperienceTechnologies.Select(et => new TechnologyModel
                {
                    Id = et.TechnologyId,
                    Name = et.Technology.Name
                })));
        
        CreateMap<ExperienceAddDTO, Experience>()
            .ForMember(dest => dest.ExperienceTechnologies, opt => opt.Ignore())
            .AfterMap((src, dest, context) =>
            {
                if (src.TechnologyIds != null && src.TechnologyIds.Any())
                {
                    dest.ExperienceTechnologies = src.TechnologyIds
                        .Select(techId => new ExperienceTechnology
                        {
                            ExperienceId = dest.Id,
                            TechnologyId = techId
                        }).ToList();
                }
            });
    }
    
    private static string CalculateDuration(DateTime startDate, DateTime? endDate)
    {
        var end = endDate ?? DateTime.Now;
        var duration = end - startDate;
        
        var years = duration.Days / 365;
        var months = (duration.Days % 365) / 30;
        
        if (years > 0 && months > 0)
            return $"{years} yıl {months} ay";
        else if (years > 0)
            return $"{years} yıl";
        else if (months > 0)
            return $"{months} ay";
        else
            return "1 aydan az";
    }
}
```

### SkillMapProfile.cs

Yetenek mapping tanımlamaları.

```csharp
public class SkillMapProfile : Profile
{
    public SkillMapProfile()
    {
        CreateMap<Skill, SkillGetDTO>()
            .ForMember(dest => dest.SubSkillCount, 
                opt => opt.MapFrom(src => src.SubSkills.Count))
            .ForMember(dest => dest.LevelPercentage, 
                opt => opt.MapFrom(src => src.Level * 20)); // 5 üzerinden 100'e çevir
        
        CreateMap<Skill, GetSkillWithSubSkillsModel>()
            .ForMember(dest => dest.SkillName, 
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SubSkills, 
                opt => opt.MapFrom(src => src.SubSkills))
            .ForMember(dest => dest.TotalSubSkills, 
                opt => opt.MapFrom(src => src.SubSkills.Count));
        
        CreateMap<SkillAddDTO, Skill>();
        
        CreateMap<SkillUpdateDTO, Skill>()
            .ForAllOtherMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
```

## Response Mapping Profilleri

### CvResponseDTOMappingProfile.cs

CV response için kompleks mapping.

```csharp
public class CvResponseDTOMappingProfile : Profile
{
    public CvResponseDTOMappingProfile()
    {
        CreateMap<CvResponseModel, CvResponseDTO>()
            .ForMember(dest => dest.Summary, 
                opt => opt.MapFrom(src => GenerateSummary(src)))
            .ForMember(dest => dest.TotalSkillCount, 
                opt => opt.MapFrom(src => src.Skills.Count + src.Skills.Sum(s => s.SubSkills.Count)))
            .ForMember(dest => dest.FeaturedTechnologies, 
                opt => opt.MapFrom(src => GetFeaturedTechnologies(src.AllTechnologies)));
    }
    
    private static string GenerateSummary(CvResponseModel model)
    {
        var yearsOfExperience = model.TotalYearsOfExperience;
        var skillCount = model.Skills.Count;
        var techCount = model.AllTechnologies.Count;
        
        return $"{yearsOfExperience} yıllık deneyim, {skillCount} ana yetenek alanı, {techCount} teknoloji";
    }
    
    private static List<string> GetFeaturedTechnologies(List<string> allTechnologies)
    {
        // En popüler 5 teknolojiyi döndür
        return allTechnologies
            .GroupBy(t => t)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();
    }
}
```

## Custom Type Converters

Özel tip dönüştürücüler için örnek:

```csharp
public class StringToSlugConverter : IValueConverter<string, string>
{
    public string Convert(string sourceMember, ResolutionContext context)
    {
        return sourceMember?.ToSlug() ?? string.Empty;
    }
}

public class DateTimeToRelativeTimeConverter : IValueConverter<DateTime, string>
{
    public string Convert(DateTime sourceMember, ResolutionContext context)
    {
        return sourceMember.ToRelativeTime();
    }
}
```

## Configuration ve Kullanım

### Startup Configuration

```csharp
// Program.cs veya Startup.cs
builder.Services.AddAutoMapperConfiguration();

// Validation (opsiyonel)
var app = builder.Build();
app.Services.ValidateMapperConfiguration();
```

### Service Layer Kullanımı

```csharp
public class BlogPostService
{
    private readonly IMapper _mapper;
    
    public async Task<BlogPostGetDTO> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<BlogPostGetDTO>(entity);
    }
    
    public async Task<BlogPostGetDTO> CreateAsync(BlogPostAddDTO dto)
    {
        var entity = _mapper.Map<BlogPost>(dto);
        var created = await _repository.AddAsync(entity);
        return _mapper.Map<BlogPostGetDTO>(created);
    }
    
    public async Task UpdateAsync(Guid id, BlogPostUpdateDTO dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        _mapper.Map(dto, entity); // Mevcut entity'yi güncelle
        await _repository.UpdateAsync(entity);
    }
}
```

## Best Practices

1. **Profile Organization**: Her entity için ayrı profile oluşturun
2. **Null Handling**: Null değerleri uygun şekilde handle edin
3. **Performance**: Kompleks mapping'lerde performansa dikkat edin
4. **Validation**: Configuration'ı validate edin
5. **Naming Convention**: Profile isimleri EntityNameMapProfile şeklinde olmalı
6. **Avoid Circular References**: Döngüsel referanslardan kaçının
7. **Use AfterMap Sparingly**: AfterMap'i minimum kullanın
8. **Test Mappings**: Mapping'ler için unit test yazın