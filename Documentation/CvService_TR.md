# TahaMucasirogluBlog.Service.Cv - CV Service Projesi Dokümantasyonu

## Proje Amacı

Bu proje, CV (özgeçmiş) ile ilgili özel iş mantığını yöneten service sınıflarını içerir. CV verilerini toplar, format eder ve sunuma hazır hale getirir. Database service'lerden farklı olarak, birden fazla entity'den veri toplayarak kompleks CV response'ları oluşturur.

## Proje Yapısı

```
TahaMucasirogluBlog.Service.Cv/
├── Abstract/
│   └── ICvService.cs
├── Base/
│   └── (Base service classes if needed)
└── Concrete/
    └── CvService.cs
```

## Interface Tanımları

### ICvService.cs

CV service için ana interface - sadece tek bir metod içerir.

```csharp
public interface ICvService
{
    /// <summary>
    /// Tüm CV verilerini birleştirerek döndürür
    /// </summary>
    /// <returns>CV response DTO</returns>
    Task<IReturn<CvResponseDTO>> GetCV();
}
```

## Concrete Implementation

### CvService.cs

CV service'in ana implementasyonu - gerçek kod yapısına göre.

```csharp
public class CvService : ICvService
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly IInfoRepository _infoRepository;
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CvService> _logger;
    
    public CvService(
        IExperienceRepository experienceRepository,
        IInfoRepository infoRepository,
        ISkillRepository skillRepository,
        IMapper mapper,
        ILogger<CvService> logger)
    {
        _experienceRepository = experienceRepository;
        _infoRepository = infoRepository;
        _skillRepository = skillRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IReturn<CvResponseDTO>> GetCV()
    {
        try
        {
            _logger.LogInformation("CV verileri getiriliyor...");
            
            // Üç ana veri kaynağından paralel olarak veri çek
            var tasks = new Task[]
            {
                GetInfoDataAsync(),
                GetExperienceDataAsync(),
                GetSkillDataAsync()
            };
            
            await Task.WhenAll(tasks);
            
            // Her bir task'in sonucunu al
            var infoResult = ((Task<IReturn<GetInfoDTO>>)tasks[0]).Result;
            var experienceResult = ((Task<IReturn<List<GetExperienceWithTechnologyAndTypeDTO>>>)tasks[1]).Result;
            var skillResult = ((Task<IReturn<List<GetSkillWithSubSkillsDTO>>>)tasks[2]).Result;
            
            // Hata kontrolü
            if (!infoResult.IsSuccess)
            {
                _logger.LogError("Info verileri alınamadı: {Message}", infoResult.Message);
                return new ErrorReturn<CvResponseDTO>(infoResult.Message);
            }
            
            if (!experienceResult.IsSuccess)
            {
                _logger.LogError("Experience verileri alınamadı: {Message}", experienceResult.Message);
                return new ErrorReturn<CvResponseDTO>(experienceResult.Message);
            }
            
            if (!skillResult.IsSuccess)
            {
                _logger.LogError("Skill verileri alınamadı: {Message}", skillResult.Message);
                return new ErrorReturn<CvResponseDTO>(skillResult.Message);
            }
            
            // CV Response DTO oluştur
            var cvResponse = new CvResponseDTO
            {
                Info = infoResult.Data,
                Experiences = experienceResult.Data,
                Skills = skillResult.Data,
                SocialLinks = new List<GetSocialLinkDTO>() // Henüz implementasyonda yok
            };
            
            _logger.LogInformation("CV verileri başarıyla birleştirildi");
            
            return new SuccessReturn<CvResponseDTO>(cvResponse, "CV verileri başarıyla getirildi");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CV verileri getirilirken hata oluştu");
            return new ErrorReturn<CvResponseDTO>("CV verileri getirilirken bir hata oluştu");
        }
    }
    
    private async Task<IReturn<GetInfoDTO>> GetInfoDataAsync()
    {
        try
        {
            var infoEntities = await _infoRepository.GetAllAsync();
            
            if (!infoEntities.IsSuccess || infoEntities.Data == null || !infoEntities.Data.Any())
            {
                return new ErrorReturn<GetInfoDTO>("Info verisi bulunamadı");
            }
            
            // İlk info kaydını al (tek kişilik CV sistemi)
            var firstInfo = infoEntities.Data.First();
            var infoDto = _mapper.Map<GetInfoDTO>(firstInfo);
            
            return new SuccessReturn<GetInfoDTO>(infoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Info verileri getirilirken hata oluştu");
            return new ErrorReturn<GetInfoDTO>("Info verileri getirilemedi");
        }
    }
    
    private async Task<IReturn<List<GetExperienceWithTechnologyAndTypeDTO>>> GetExperienceDataAsync()
    {
        try
        {
            var experienceEntities = await _experienceRepository.GetAllWithIncludesAsync(
                x => x.ExperienceType,
                x => x.ExperienceTechnologies
            );
            
            if (!experienceEntities.IsSuccess)
            {
                return new ErrorReturn<List<GetExperienceWithTechnologyAndTypeDTO>>(experienceEntities.Message);
            }
            
            var experienceDtos = _mapper.Map<List<GetExperienceWithTechnologyAndTypeDTO>>(experienceEntities.Data);
            
            return new SuccessReturn<List<GetExperienceWithTechnologyAndTypeDTO>>(experienceDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Experience verileri getirilirken hata oluştu");
            return new ErrorReturn<List<GetExperienceWithTechnologyAndTypeDTO>>("Experience verileri getirilemedi");
        }
    }
    
    private async Task<IReturn<List<GetSkillWithSubSkillsDTO>>> GetSkillDataAsync()
    {
        try
        {
            var skillEntities = await _skillRepository.GetAllWithIncludesAsync(x => x.SubSkills);
            
            if (!skillEntities.IsSuccess)
            {
                return new ErrorReturn<List<GetSkillWithSubSkillsDTO>>(skillEntities.Message);
            }
            
            var skillDtos = _mapper.Map<List<GetSkillWithSubSkillsDTO>>(skillEntities.Data);
            
            return new SuccessReturn<List<GetSkillWithSubSkillsDTO>>(skillDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Skill verileri getirilirken hata oluştu");
            return new ErrorReturn<List<GetSkillWithSubSkillsDTO>>("Skill verileri getirilemedi");
        }
    }
}
```

## DTO Definitions

### CvResponseDTO.cs (Gerçek Kod)

```csharp
public record CvResponseDTO : ResponseDTO
{
    public GetInfoDTO Info { get; set; } = default!;
    public List<GetSocialLinkDTO> SocialLinks { get; set; } = default!;
    public List<GetSkillWithSubSkillsDTO> Skills { get; set; } = new();
    public List<GetExperienceWithTechnologyAndTypeDTO> Experiences { get; set; } = new();
}
```

### Kullanılan DTO'lar

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

## Repository Dependencies

CV Service aşağıdaki repository'leri kullanır:

1. **IExperienceRepository** - İş deneyimleri ve ilişkili veriler
2. **IInfoRepository** - Kişisel bilgiler
3. **ISkillRepository** - Yetenekler ve alt yetenekler

## Mapping Strategy

AutoMapper kullanılarak entity'ler DTO'lara dönüştürülür:

```csharp
// Experience mapping
CreateMap<Experience, GetExperienceWithTechnologyAndTypeDTO>()
    .ForMember(dest => dest.ExperienceType, opt => opt.MapFrom(src => src.ExperienceType))
    .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.ExperienceTechnologies));

// Skill mapping
CreateMap<Skill, GetSkillWithSubSkillsDTO>()
    .ForMember(dest => dest.SubSkills, opt => opt.MapFrom(src => src.SubSkills));

// Info mapping
CreateMap<Info, GetInfoDTO>();
```

## Error Handling

Service, consistent error handling için IReturn<T> pattern kullanır:

```csharp
public interface IReturn<T>
{
    bool IsSuccess { get; }
    string Message { get; }
    T Data { get; }
}
```

### Error Scenarios
1. **Repository Error** - Veri erişim hatası
2. **Mapping Error** - Entity-DTO dönüşüm hatası
3. **Data Not Found** - Gerekli veriler bulunamadı
4. **General Exception** - Beklenmeyen hatalar

## Performance Considerations

1. **Parallel Data Fetching** - Üç repository'den paralel veri çekme
2. **Include Strategy** - Eager loading ile ilişkili verileri tek sorguda çekme
3. **Async Operations** - Tüm repository işlemleri async
4. **Logging** - Performance tracking için structured logging

## Usage in Controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class CvController : ControllerBase
{
    private readonly ICvService _cvService;
    
    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        var result = await _cvService.GetCV();
        
        if (result.IsSuccess)
            return Ok(result.Data);
        
        return BadRequest(result.Message);
    }
}
```

## Best Practices

1. **Single Responsibility**: CV service sadece CV verilerini aggregate eder
2. **Dependency Injection**: Repository'ler DI ile inject edilir
3. **Async/Await**: Tüm I/O operations async
4. **Error Handling**: Consistent error handling pattern
5. **Logging**: Structured logging ile traceability
6. **Parallel Processing**: Bağımsız verileri paralel çekme
7. **Mapping**: AutoMapper ile clean object transformation

## Future Enhancements

Proje geliştirilirken eklenebilecek özellikler:

1. **Caching**: Frequently accessed CV data için cache
2. **User-specific CV**: Kullanıcı bazlı CV verisi
3. **Export Features**: PDF, Word export functionality
4. **Analytics**: CV view tracking ve analytics
5. **Social Links**: SocialLink entity'si için implement
6. **Filtering**: Skills, experiences filtering options