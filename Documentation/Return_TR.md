# TahaMucasirogluBlog.Domain.Return - Return Types Projesi Dokümantasyonu

## Proje Amacı

Bu proje, uygulama genelinde kullanılan standart response/return tiplerini içerir. Tutarlı ve tip güvenli bir response yapısı sağlayarak, hata yönetimi ve başarılı işlem sonuçlarının standardizasyonunu sağlar.

## Proje Yapısı

```
TahaMucasirogluBlog.Domain.Return/
├── Abstract/
│   └── IReturn.cs
├── Base/
│   └── Return.cs
├── Concrete/
│   ├── ErrorReturn.cs
│   └── SuccessReturn.cs
└── Constant/
    └── NullDataSuccess.cs
```

## Temel Bileşenler

### Abstract/IReturn.cs

Tüm return tiplerinin uygulaması gereken temel interface.

```csharp
public interface IReturn
{
    bool IsSuccess { get; }
    string Message { get; }
    int StatusCode { get; }
}

public interface IReturn<T> : IReturn
{
    T Data { get; }
}
```

### Base/Return.cs

IReturn interface'ini implement eden abstract base class.

```csharp
public abstract class Return : IReturn
{
    public bool IsSuccess { get; protected set; }
    public string Message { get; protected set; }
    public int StatusCode { get; protected set; }
    
    protected Return(bool isSuccess, string message, int statusCode)
    {
        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
    }
}

public abstract class Return<T> : Return, IReturn<T>
{
    public T Data { get; protected set; }
    
    protected Return(bool isSuccess, string message, int statusCode, T data) 
        : base(isSuccess, message, statusCode)
    {
        Data = data;
    }
}
```

## Concrete Return Tipleri

### SuccessReturn.cs

Başarılı işlem sonuçları için kullanılan return tipler.

```csharp
public class SuccessReturn : Return
{
    public SuccessReturn(string message = "İşlem başarıyla tamamlandı.") 
        : base(true, message, 200)
    {
    }
    
    public SuccessReturn(string message, int statusCode) 
        : base(true, message, statusCode)
    {
    }
}

public class SuccessReturn<T> : Return<T>
{
    public SuccessReturn(T data, string message = "İşlem başarıyla tamamlandı.") 
        : base(true, message, 200, data)
    {
    }
    
    public SuccessReturn(T data, string message, int statusCode) 
        : base(true, message, statusCode, data)
    {
    }
}
```

### ErrorReturn.cs

Hata durumları için kullanılan return tipler.

```csharp
public class ErrorReturn : Return
{
    public string ErrorCode { get; }
    public List<string> Errors { get; }
    
    public ErrorReturn(string message = "Bir hata oluştu.") 
        : base(false, message, 400)
    {
        Errors = new List<string>();
    }
    
    public ErrorReturn(string message, int statusCode) 
        : base(false, message, statusCode)
    {
        Errors = new List<string>();
    }
    
    public ErrorReturn(string message, string errorCode, int statusCode = 400) 
        : base(false, message, statusCode)
    {
        ErrorCode = errorCode;
        Errors = new List<string>();
    }
    
    public ErrorReturn(string message, List<string> errors, int statusCode = 400) 
        : base(false, message, statusCode)
    {
        Errors = errors ?? new List<string>();
    }
}

public class ErrorReturn<T> : Return<T>
{
    public string ErrorCode { get; }
    public List<string> Errors { get; }
    
    public ErrorReturn(string message = "Bir hata oluştu.") 
        : base(false, message, 400, default(T))
    {
        Errors = new List<string>();
    }
    
    public ErrorReturn(string message, int statusCode) 
        : base(false, message, statusCode, default(T))
    {
        Errors = new List<string>();
    }
}
```

### Constant/NullDataSuccess.cs

Data'sı null olan başarılı sonuçlar için özel sabit.

```csharp
public static class NullDataSuccess
{
    public static SuccessReturn<T> Create<T>(string message = "İşlem başarılı, ancak veri bulunamadı.")
    {
        return new SuccessReturn<T>(default(T), message, 204); // 204 No Content
    }
}
```

## Kullanım Senaryoları

### 1. Service Layer Kullanımı

```csharp
public class BlogPostService
{
    public async Task<IReturn<BlogPostGetDTO>> GetByIdAsync(Guid id)
    {
        try
        {
            var blogPost = await _repository.GetByIdAsync(id);
            
            if (blogPost == null)
                return new ErrorReturn<BlogPostGetDTO>("Blog yazısı bulunamadı.", 404);
            
            var dto = _mapper.Map<BlogPostGetDTO>(blogPost);
            return new SuccessReturn<BlogPostGetDTO>(dto, "Blog yazısı başarıyla getirildi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Blog yazısı getirilirken hata oluştu. Id: {Id}", id);
            return new ErrorReturn<BlogPostGetDTO>("İşlem sırasında bir hata oluştu.", 500);
        }
    }
    
    public async Task<IReturn> DeleteAsync(Guid id)
    {
        try
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists)
                return new ErrorReturn("Silinecek blog yazısı bulunamadı.", 404);
            
            await _repository.DeleteAsync(id);
            return new SuccessReturn("Blog yazısı başarıyla silindi.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Blog yazısı silinirken hata oluştu. Id: {Id}", id);
            return new ErrorReturn("Silme işlemi sırasında bir hata oluştu.", 500);
        }
    }
}
```

### 2. Controller Kullanımı

```csharp
[ApiController]
[Route("api/[controller]")]
public class BlogPostController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _blogPostService.GetByIdAsync(id);
        
        if (result.IsSuccess)
            return Ok(result);
        
        return StatusCode(result.StatusCode, result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(BlogPostAddDTO dto)
    {
        var result = await _blogPostService.CreateAsync(dto);
        
        if (result.IsSuccess)
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        
        return BadRequest(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _blogPostService.DeleteAsync(id);
        
        return result.IsSuccess ? NoContent() : StatusCode(result.StatusCode, result);
    }
}
```

### 3. Validation ile Kullanım

```csharp
public class BlogPostService
{
    public async Task<IReturn<BlogPostGetDTO>> CreateAsync(BlogPostAddDTO dto)
    {
        // Validation
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return new ErrorReturn<BlogPostGetDTO>("Validation hatası oluştu.", errors);
        }
        
        try
        {
            var entity = _mapper.Map<BlogPost>(dto);
            var created = await _repository.AddAsync(entity);
            var resultDto = _mapper.Map<BlogPostGetDTO>(created);
            
            return new SuccessReturn<BlogPostGetDTO>(resultDto, "Blog yazısı başarıyla oluşturuldu.", 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Blog yazısı oluşturulurken hata oluştu.");
            return new ErrorReturn<BlogPostGetDTO>("İşlem sırasında bir hata oluştu.", 500);
        }
    }
}
```

### 4. Batch İşlemler

```csharp
public class BlogPostService
{
    public async Task<IReturn<BatchOperationResult>> BulkDeleteAsync(List<Guid> ids)
    {
        var result = new BatchOperationResult
        {
            TotalCount = ids.Count,
            SuccessCount = 0,
            FailedCount = 0,
            FailedIds = new List<Guid>()
        };
        
        foreach (var id in ids)
        {
            try
            {
                await _repository.DeleteAsync(id);
                result.SuccessCount++;
            }
            catch
            {
                result.FailedCount++;
                result.FailedIds.Add(id);
            }
        }
        
        if (result.FailedCount == 0)
            return new SuccessReturn<BatchOperationResult>(result, "Tüm kayıtlar başarıyla silindi.");
        
        if (result.SuccessCount == 0)
            return new ErrorReturn<BatchOperationResult>("Hiçbir kayıt silinemedi.");
        
        return new SuccessReturn<BatchOperationResult>(result, 
            $"{result.SuccessCount} kayıt silindi, {result.FailedCount} kayıt silinemedi.", 206);
    }
}
```

## HTTP Status Code Mapping

| Status Code | Kullanım Durumu |
|-------------|----------------|
| 200 | OK - Genel başarı |
| 201 | Created - Yeni kayıt oluşturuldu |
| 204 | No Content - Başarılı ama içerik yok |
| 400 | Bad Request - Genel hata |
| 401 | Unauthorized - Yetkilendirme hatası |
| 403 | Forbidden - Erişim yasak |
| 404 | Not Found - Kayıt bulunamadı |
| 409 | Conflict - Çakışma (duplicate vb.) |
| 422 | Unprocessable Entity - Validation hatası |
| 500 | Internal Server Error - Sunucu hatası |

## Extension Methods

```csharp
public static class ReturnExtensions
{
    // Controller için ActionResult dönüşümü
    public static IActionResult ToActionResult(this IReturn result, ControllerBase controller)
    {
        if (result.IsSuccess)
        {
            return result.StatusCode switch
            {
                201 => controller.Created("", result),
                204 => controller.NoContent(),
                _ => controller.Ok(result)
            };
        }
        
        return controller.StatusCode(result.StatusCode, result);
    }
    
    // Success kontrolü
    public static bool HasData<T>(this IReturn<T> result)
    {
        return result.IsSuccess && result.Data != null;
    }
}
```

## Best Practices

1. **Consistency**: Tüm servis metodları IReturn tipinde dönüş yapmalı
2. **Error Details**: Hata durumlarında detaylı bilgi verilmeli
3. **Status Codes**: HTTP status code'lar doğru kullanılmalı
4. **Logging**: Hata durumları loglanmalı
5. **Message Clarity**: Kullanıcıya gösterilecek mesajlar açık ve anlaşılır olmalı
6. **Type Safety**: Generic return tiplerini tercih edin