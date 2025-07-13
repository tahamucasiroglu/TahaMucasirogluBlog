# TahaMucasirogluBlog.Application.Validation - Validation Projesi Dokümantasyonu

## Proje Amacı

Bu proje, FluentValidation kütüphanesini kullanarak veri doğrulama işlemlerini yöneten validation sınıflarını içerir. DTO'ların ve model'lerin iş kurallarına uygunluğunu kontrol eder ve hata mesajlarını standardize eder.

## Proje Yapısı

```
TahaMucasirogluBlog.Application.Validation/
├── Base/
│   ├── AddValidation.cs
│   ├── DeleteValidation.cs
│   ├── RequestValidation.cs
│   ├── UpdateValidation.cs
│   └── Validator.cs
├── Concrete/
│   └── Entity/
│       └── (Entity-specific validators)
└── Extensions/
    ├── DateTimeValidateExtension.cs
    ├── DecimalValidateExtension.cs
    ├── GuidValidateExtension.cs
    ├── IntValidateExtension.cs
    ├── StringValidateExtension.cs
    └── ValidateExtension.cs
```

## Base Validation Sınıfları

### Base/Validator.cs

Tüm validator'ların inherit etmesi gereken temel abstract sınıf.

```csharp
public abstract class Validator<T> : AbstractValidator<T>
{
    protected Validator()
    {
        // Global validation ayarları
        ConfigureValidation();
    }
    
    protected virtual void ConfigureValidation()
    {
        // Türkçe mesaj ayarları
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");
        
        // Cascade mode - first failure stops
        CascadeMode = CascadeMode.Stop;
    }
    
    // Ortak validation metodları
    protected void ValidateId(Expression<Func<T, Guid>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz.")
            .Must(BeValidGuid)
            .WithMessage("{PropertyName} geçerli bir ID formatında olmalıdır.");
    }
    
    protected void ValidateEmail(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz.")
            .EmailAddress()
            .WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(255)
            .WithMessage("{PropertyName} en fazla 255 karakter olabilir.");
    }
    
    protected void ValidatePassword(Expression<Func<T, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz.")
            .MinimumLength(8)
            .WithMessage("{PropertyName} en az 8 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} en fazla 50 karakter olabilir.")
            .Must(ContainUppercase)
            .WithMessage("{PropertyName} en az bir büyük harf içermelidir.")
            .Must(ContainLowercase)
            .WithMessage("{PropertyName} en az bir küçük harf içermelidir.")
            .Must(ContainDigit)
            .WithMessage("{PropertyName} en az bir rakam içermelidir.");
    }
    
    private bool BeValidGuid(Guid guid)
    {
        return guid != Guid.Empty;
    }
    
    private bool ContainUppercase(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Any(char.IsUpper);
    }
    
    private bool ContainLowercase(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Any(char.IsLower);
    }
    
    private bool ContainDigit(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Any(char.IsDigit);
    }
}
```

### Base/AddValidation.cs

Add operasyonları için base validation.

```csharp
public abstract class AddValidation<T> : Validator<T> where T : IAddDTO
{
    protected AddValidation()
    {
        SetupCommonAddValidations();
    }
    
    protected virtual void SetupCommonAddValidations()
    {
        // Add DTO'lar için ortak validasyonlar
        ValidateCreationRules();
    }
    
    protected virtual void ValidateCreationRules()
    {
        // Override edilebilir ortak oluşturma kuralları
    }
}
```

### Base/UpdateValidation.cs

Update operasyonları için base validation.

```csharp
public abstract class UpdateValidation<T> : Validator<T> where T : IUpdateDTO
{
    protected UpdateValidation()
    {
        SetupCommonUpdateValidations();
    }
    
    protected virtual void SetupCommonUpdateValidations()
    {
        // Update DTO'lar için ortak validasyonlar
        ValidateId(x => x.Id);
        ValidateUpdateRules();
    }
    
    protected virtual void ValidateUpdateRules()
    {
        // Override edilebilir ortak güncelleme kuralları
    }
}
```

## Concrete Validation Sınıfları

### BlogPostAddDTOValidator.cs

```csharp
public class BlogPostAddDTOValidator : AddValidation<BlogPostAddDTO>
{
    private readonly IBlogPostRepository _repository;
    
    public BlogPostAddDTOValidator(IBlogPostRepository repository)
    {
        _repository = repository;
        SetupValidationRules();
    }
    
    private void SetupValidationRules()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Başlık boş olamaz.")
            .MinimumLength(3)
            .WithMessage("Başlık en az 3 karakter olmalıdır.")
            .MaximumLength(200)
            .WithMessage("Başlık en fazla 200 karakter olabilir.")
            .MustAsync(BeUniqueTitleAsync)
            .WithMessage("Bu başlıkta bir yazı zaten mevcut.");
        
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("İçerik boş olamaz.")
            .MinimumLength(10)
            .WithMessage("İçerik en az 10 karakter olmalıdır.")
            .MaximumLength(50000)
            .WithMessage("İçerik en fazla 50.000 karakter olabilir.");
        
        RuleFor(x => x.Summary)
            .MaximumLength(500)
            .WithMessage("Özet en fazla 500 karakter olabilir.")
            .Must((dto, summary) => ValidateSummaryLength(dto.Content, summary))
            .WithMessage("Özet, içeriğin %10'undan fazla olamaz.");
        
        ValidateId(x => x.UserId);
        
        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .WithMessage("En az bir kategori seçilmelidir.")
            .Must(x => x != null && x.Count <= 5)
            .WithMessage("En fazla 5 kategori seçilebilir.")
            .MustAsync(AllCategoriesExistAsync)
            .WithMessage("Seçilen kategorilerden bir veya birkaçı geçersiz.");
        
        RuleFor(x => x.TagIds)
            .Must(x => x == null || x.Count <= 10)
            .WithMessage("En fazla 10 etiket seçilebilir.")
            .MustAsync(AllTagsExistAsync)
            .WithMessage("Seçilen etiketlerden bir veya birkaçı geçersiz.")
            .When(x => x.TagIds != null && x.TagIds.Any());
        
        RuleFor(x => x.PublishedDate)
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Yayın tarihi bugünden önce olamaz.")
            .When(x => x.PublishedDate.HasValue);
    }
    
    private async Task<bool> BeUniqueTitleAsync(string title, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(title))
            return true;
        
        var exists = await _repository.ExistsByTitleAsync(title);
        return !exists;
    }
    
    private async Task<bool> AllCategoriesExistAsync(List<Guid> categoryIds, CancellationToken cancellationToken)
    {
        if (categoryIds == null || !categoryIds.Any())
            return true;
        
        var existingCount = await _repository.GetCategoryCountAsync(categoryIds);
        return existingCount == categoryIds.Count;
    }
    
    private async Task<bool> AllTagsExistAsync(List<Guid> tagIds, CancellationToken cancellationToken)
    {
        if (tagIds == null || !tagIds.Any())
            return true;
        
        var existingCount = await _repository.GetTagCountAsync(tagIds);
        return existingCount == tagIds.Count;
    }
    
    private bool ValidateSummaryLength(string content, string summary)
    {
        if (string.IsNullOrEmpty(summary) || string.IsNullOrEmpty(content))
            return true;
        
        return summary.Length <= content.Length * 0.1; // %10 kuralı
    }
}
```

### UserRegisterDTOValidator.cs

```csharp
public class UserRegisterDTOValidator : AddValidation<UserRegisterDTO>
{
    private readonly IUserRepository _userRepository;
    
    public UserRegisterDTOValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        SetupValidationRules();
    }
    
    private void SetupValidationRules()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Ad boş olamaz.")
            .MinimumLength(2)
            .WithMessage("Ad en az 2 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Ad en fazla 50 karakter olabilir.")
            .Matches(@"^[a-zA-ZçğıöşüÇĞIİÖŞÜ\s]+$")
            .WithMessage("Ad sadece harf içerebilir.");
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Soyad boş olamaz.")
            .MinimumLength(2)
            .WithMessage("Soyad en az 2 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Soyad en fazla 50 karakter olabilir.")
            .Matches(@"^[a-zA-ZçğıöşüÇĞIİÖŞÜ\s]+$")
            .WithMessage("Soyad sadece harf içerebilir.");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("E-posta boş olamaz.")
            .EmailAddress()
            .WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MustAsync(BeUniqueEmailAsync)
            .WithMessage("Bu e-posta adresi zaten kullanılıyor.");
        
        ValidatePassword(x => x.Password);
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Şifre tekrarı boş olamaz.")
            .Equal(x => x.Password)
            .WithMessage("Şifreler eşleşmiyor.");
        
        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Today.AddYears(-13))
            .WithMessage("En az 13 yaşında olmalısınız.")
            .GreaterThan(DateTime.Today.AddYears(-120))
            .WithMessage("Geçersiz doğum tarihi.")
            .When(x => x.DateOfBirth.HasValue);
    }
    
    private async Task<bool> BeUniqueEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(email))
            return true;
        
        var exists = await _userRepository.ExistsByEmailAsync(email);
        return !exists;
    }
}
```

## Validation Extensions

### Extensions/StringValidateExtension.cs

String validation için extension metodlar.

```csharp
public static class StringValidateExtension
{
    public static IRuleBuilderOptions<T, string> NotEmptyWithMessage<T>(
        this IRuleBuilder<T, string> ruleBuilder, 
        string message = "{PropertyName} boş olamaz.")
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage(message);
    }
    
    public static IRuleBuilderOptions<T, string> LengthWithMessage<T>(
        this IRuleBuilder<T, string> ruleBuilder, 
        int min, 
        int max, 
        string message = "{PropertyName} {MinLength} ile {MaxLength} karakter arasında olmalıdır.")
    {
        return ruleBuilder
            .Length(min, max)
            .WithMessage(message);
    }
    
    public static IRuleBuilderOptions<T, string> MustBeSlug<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^[a-z0-9]+(?:-[a-z0-9]+)*$")
            .WithMessage("{PropertyName} geçerli bir slug formatında olmalıdır (küçük harf, rakam ve tire).");
    }
    
    public static IRuleBuilderOptions<T, string> MustBeUrl<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$")
            .WithMessage("{PropertyName} geçerli bir URL formatında olmalıdır.");
    }
    
    public static IRuleBuilderOptions<T, string> MustBePhoneNumber<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^(\+90|0)?[0-9]{10}$")
            .WithMessage("{PropertyName} geçerli bir telefon numarası formatında olmalıdır.");
    }
}
```

### Extensions/GuidValidateExtension.cs

```csharp
public static class GuidValidateExtension
{
    public static IRuleBuilderOptions<T, Guid> NotEmptyGuid<T>(
        this IRuleBuilder<T, Guid> ruleBuilder,
        string message = "{PropertyName} boş olamaz.")
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage(message);
    }
    
    public static IRuleBuilderOptions<T, Guid?> NotEmptyGuid<T>(
        this IRuleBuilder<T, Guid?> ruleBuilder,
        string message = "{PropertyName} boş olamaz.")
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage(message)
            .Must(guid => guid.HasValue && guid.Value != Guid.Empty)
            .WithMessage(message);
    }
}
```

## Configuration ve Kullanım

### Dependency Injection Configuration

```csharp
public static class ValidationExtensions
{
    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        // FluentValidation
        services.AddValidatorsFromAssembly(typeof(ValidationExtensions).Assembly);
        
        // Custom validator behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}

// MediatR için validation behavior
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            
            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();
            
            if (failures.Count != 0)
                throw new ValidationException(failures);
        }
        
        return await next();
    }
}
```

### Controller Usage

```csharp
[ApiController]
[Route("api/[controller]")]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;
    private readonly IValidator<BlogPostAddDTO> _addValidator;
    
    [HttpPost]
    public async Task<IActionResult> Create(BlogPostAddDTO dto)
    {
        // Manual validation
        var validationResult = await _addValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var result = await _blogPostService.CreateAsync(dto);
        return Ok(result);
    }
}
```

## Custom Validation Rules

```csharp
public static class CustomValidators
{
    public static IRuleBuilderOptions<T, string> MustBeValidSlug<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(BeValidSlug)
            .WithMessage("{PropertyName} geçerli bir slug olmalıdır.");
    }
    
    private static bool BeValidSlug(string slug)
    {
        if (string.IsNullOrEmpty(slug))
            return false;
        
        return Regex.IsMatch(slug, @"^[a-z0-9]+(?:-[a-z0-9]+)*$");
    }
    
    public static IRuleBuilderOptions<T, DateTime> MustBeBusinessDay<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder.Must(BeBusinessDay)
            .WithMessage("{PropertyName} iş günü olmalıdır.");
    }
    
    private static bool BeBusinessDay(DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday && 
               date.DayOfWeek != DayOfWeek.Sunday;
    }
}
```

## Best Practices

1. **Validator Per DTO**: Her DTO için ayrı validator oluşturun
2. **Async Validation**: Database validation'ları async yapın
3. **Clear Messages**: Hata mesajları kullanıcı dostu olmalı
4. **Performance**: Validation kurallarında performansa dikkat edin
5. **Reusability**: Ortak validation kurallarını extension'larda tanımlayın
6. **Testing**: Validator'lar için unit test yazın
7. **Localization**: Çoklu dil desteği için resource dosyaları kullanın