# TahaMucasirogluBlog.Service.Database - Database Service Projesi Dokümantasyonu

## Proje Amacı

Bu proje, Repository pattern üzerine inşa edilmiş, iş mantığı katmanındaki (business logic) database operasyonlarını yöneten service sınıflarını içerir. Repository'den daha üst seviyede business rules'ları implement eder ve transaction management sağlar.

## Proje Yapısı

```
TahaMucasirogluBlog.Service.Database/
├── Abstract/
│   ├── IBlogPostCategoryDatabaseService.cs
│   ├── IBlogPostDatabaseService.cs
│   ├── IBlogPostTagDatabaseService.cs
│   ├── ICategoryDatabaseService.cs
│   ├── ICommentDatabaseService.cs
│   ├── IExperienceDatabaseService.cs
│   ├── IExperienceTechnologyDatabaseService.cs
│   ├── IExperienceTypeDatabaseService.cs
│   ├── IInfoDatabaseService.cs
│   ├── ISkillDatabaseService.cs
│   ├── ISocialLinkDatabaseService.cs
│   ├── ISubSkillDatabaseService.cs
│   ├── ITagDatabaseService.cs
│   └── IUserDatabaseService.cs
├── Base/
│   └── DatabaseService.cs
└── Concrete/
    ├── BlogPostCategoryDatabaseService.cs
    ├── BlogPostDatabaseService.cs
    ├── BlogPostTagDatabaseService.cs
    ├── CategoryDatabaseService.cs
    ├── CommentDatabaseService.cs
    ├── ExperienceDatabaseService.cs
    ├── ExperienceTechnologyDatabaseService.cs
    ├── ExperienceTypeDatabaseService.cs
    ├── InfoDatabaseService.cs
    ├── SkillDatabaseService.cs
    ├── SocialLinkDatabaseService.cs
    ├── SubSkillDatabaseService.cs
    ├── TagDatabaseService.cs
    └── UserDatabaseService.cs
```

## Base Database Service

### DatabaseService.cs

Tüm database service'lerin inherit etmesi gereken base sınıf.

```csharp
public abstract class DatabaseService<T, TRepository> : IDatabaseService<T>
    where T : class, IEntity
    where TRepository : IRepository<T>
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;
    protected readonly ILogger<DatabaseService<T, TRepository>> _logger;
    protected readonly IUnitOfWork _unitOfWork;
    
    protected DatabaseService(
        TRepository repository,
        IMapper mapper,
        ILogger<DatabaseService<T, TRepository>> logger,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    
    public virtual async Task<IReturn<TGetDTO>> GetByIdAsync<TGetDTO>(Guid id) where TGetDTO : class
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
            {
                _logger.LogWarning("{EntityType} not found with ID: {Id}", typeof(T).Name, id);
                return new ErrorReturn<TGetDTO>($"{typeof(T).Name} bulunamadı.", 404);
            }
            
            var dto = _mapper.Map<TGetDTO>(entity);
            return new SuccessReturn<TGetDTO>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting {EntityType} by ID: {Id}", typeof(T).Name, id);
            return new ErrorReturn<TGetDTO>("Veri getirilirken bir hata oluştu.", 500);
        }
    }
    
    public virtual async Task<IReturn<List<TGetDTO>>> GetAllAsync<TGetDTO>() where TGetDTO : class
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<TGetDTO>>(entities);
            
            return new SuccessReturn<List<TGetDTO>>(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all {EntityType}", typeof(T).Name);
            return new ErrorReturn<List<TGetDTO>>("Veriler getirilirken bir hata oluştu.", 500);
        }
    }
    
    public virtual async Task<IReturn<TGetDTO>> AddAsync<TAddDTO, TGetDTO>(TAddDTO dto)
        where TAddDTO : class, IAddDTO
        where TGetDTO : class
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            var entity = _mapper.Map<T>(dto);
            
            // Business rules validation
            var validationResult = await ValidateForAddAsync(entity, dto);
            if (!validationResult.IsSuccess)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn<TGetDTO>(validationResult.Message, 400);
            }
            
            // Pre-add processing
            await PreAddProcessingAsync(entity, dto);
            
            var addedEntity = await _repository.AddAsync(entity);
            
            // Post-add processing
            await PostAddProcessingAsync(addedEntity, dto);
            
            await _unitOfWork.CommitTransactionAsync();
            
            var resultDto = _mapper.Map<TGetDTO>(addedEntity);
            
            _logger.LogInformation("{EntityType} created with ID: {Id}", typeof(T).Name, addedEntity.Id);
            
            return new SuccessReturn<TGetDTO>(resultDto, $"{typeof(T).Name} başarıyla oluşturuldu.", 201);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error adding {EntityType}", typeof(T).Name);
            return new ErrorReturn<TGetDTO>("Kayıt eklenirken bir hata oluştu.", 500);
        }
    }
    
    public virtual async Task<IReturn<TGetDTO>> UpdateAsync<TUpdateDTO, TGetDTO>(TUpdateDTO dto)
        where TUpdateDTO : class, IUpdateDTO
        where TGetDTO : class
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            var existingEntity = await _repository.GetByIdAsync(dto.Id);
            if (existingEntity == null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn<TGetDTO>($"{typeof(T).Name} bulunamadı.", 404);
            }
            
            // Business rules validation
            var validationResult = await ValidateForUpdateAsync(existingEntity, dto);
            if (!validationResult.IsSuccess)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn<TGetDTO>(validationResult.Message, 400);
            }
            
            // Pre-update processing
            await PreUpdateProcessingAsync(existingEntity, dto);
            
            _mapper.Map(dto, existingEntity);
            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            
            // Post-update processing
            await PostUpdateProcessingAsync(updatedEntity, dto);
            
            await _unitOfWork.CommitTransactionAsync();
            
            var resultDto = _mapper.Map<TGetDTO>(updatedEntity);
            
            _logger.LogInformation("{EntityType} updated with ID: {Id}", typeof(T).Name, updatedEntity.Id);
            
            return new SuccessReturn<TGetDTO>(resultDto, $"{typeof(T).Name} başarıyla güncellendi.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error updating {EntityType} with ID: {Id}", typeof(T).Name, dto.Id);
            return new ErrorReturn<TGetDTO>("Kayıt güncellenirken bir hata oluştu.", 500);
        }
    }
    
    public virtual async Task<IReturn> DeleteAsync(Guid id)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn($"{typeof(T).Name} bulunamadı.", 404);
            }
            
            // Business rules validation for delete
            var validationResult = await ValidateForDeleteAsync(entity);
            if (!validationResult.IsSuccess)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn(validationResult.Message, 400);
            }
            
            // Pre-delete processing
            await PreDeleteProcessingAsync(entity);
            
            await _repository.DeleteAsync(id);
            
            // Post-delete processing
            await PostDeleteProcessingAsync(entity);
            
            await _unitOfWork.CommitTransactionAsync();
            
            _logger.LogInformation("{EntityType} deleted with ID: {Id}", typeof(T).Name, id);
            
            return new SuccessReturn($"{typeof(T).Name} başarıyla silindi.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error deleting {EntityType} with ID: {Id}", typeof(T).Name, id);
            return new ErrorReturn("Kayıt silinirken bir hata oluştu.", 500);
        }
    }
    
    // Virtual methods for customization
    protected virtual async Task<IReturn> ValidateForAddAsync<TAddDTO>(T entity, TAddDTO dto)
    {
        return new SuccessReturn("Validation passed");
    }
    
    protected virtual async Task<IReturn> ValidateForUpdateAsync<TUpdateDTO>(T entity, TUpdateDTO dto)
    {
        return new SuccessReturn("Validation passed");
    }
    
    protected virtual async Task<IReturn> ValidateForDeleteAsync(T entity)
    {
        return new SuccessReturn("Validation passed");
    }
    
    protected virtual async Task PreAddProcessingAsync<TAddDTO>(T entity, TAddDTO dto)
    {
        // Override in derived classes
    }
    
    protected virtual async Task PostAddProcessingAsync<TAddDTO>(T entity, TAddDTO dto)
    {
        // Override in derived classes
    }
    
    protected virtual async Task PreUpdateProcessingAsync<TUpdateDTO>(T entity, TUpdateDTO dto)
    {
        // Override in derived classes
    }
    
    protected virtual async Task PostUpdateProcessingAsync<TUpdateDTO>(T entity, TUpdateDTO dto)
    {
        // Override in derived classes
    }
    
    protected virtual async Task PreDeleteProcessingAsync(T entity)
    {
        // Override in derived classes
    }
    
    protected virtual async Task PostDeleteProcessingAsync(T entity)
    {
        // Override in derived classes
    }
}
```

## Concrete Database Services

### BlogPostDatabaseService.cs

Blog yazıları için özel business logic'li database service.

```csharp
public interface IBlogPostDatabaseService : IDatabaseService<BlogPost>
{
    Task<IReturn<List<BlogPostGetDTO>>> GetPublishedAsync();
    Task<IReturn<BlogPostGetDTO>> GetBySlugAsync(string slug);
    Task<IReturn<List<BlogPostGetDTO>>> GetByCategoryAsync(Guid categoryId);
    Task<IReturn<List<BlogPostGetDTO>>> SearchAsync(string searchTerm);
    Task<IReturn> PublishAsync(Guid id);
    Task<IReturn> UnpublishAsync(Guid id);
    Task<IReturn> IncrementViewCountAsync(Guid id);
    Task<IReturn<PagedResult<BlogPostGetDTO>>> GetPagedAsync(int page, int pageSize, BlogPostFilterDTO filter);
}

public class BlogPostDatabaseService : DatabaseService<BlogPost, IBlogPostRepository>, IBlogPostDatabaseService
{
    private readonly ICategoryDatabaseService _categoryService;
    private readonly ITagDatabaseService _tagService;
    private readonly IEmailService _emailService;
    
    public BlogPostDatabaseService(
        IBlogPostRepository repository,
        IMapper mapper,
        ILogger<BlogPostDatabaseService> logger,
        IUnitOfWork unitOfWork,
        ICategoryDatabaseService categoryService,
        ITagDatabaseService tagService,
        IEmailService emailService)
        : base(repository, mapper, logger, unitOfWork)
    {
        _categoryService = categoryService;
        _tagService = tagService;
        _emailService = emailService;
    }
    
    public async Task<IReturn<List<BlogPostGetDTO>>> GetPublishedAsync()
    {
        try
        {
            var publishedPosts = await _repository.GetPublishedAsync();
            var dtos = _mapper.Map<List<BlogPostGetDTO>>(publishedPosts);
            
            return new SuccessReturn<List<BlogPostGetDTO>>(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting published blog posts");
            return new ErrorReturn<List<BlogPostGetDTO>>("Yayınlanan yazılar getirilirken hata oluştu.");
        }
    }
    
    public async Task<IReturn<BlogPostGetDTO>> GetBySlugAsync(string slug)
    {
        try
        {
            if (string.IsNullOrEmpty(slug))
                return new ErrorReturn<BlogPostGetDTO>("Slug boş olamaz.", 400);
            
            var blogPost = await _repository.GetBySlugAsync(slug);
            
            if (blogPost == null)
                return new ErrorReturn<BlogPostGetDTO>("Blog yazısı bulunamadı.", 404);
            
            var dto = _mapper.Map<BlogPostGetDTO>(blogPost);
            return new SuccessReturn<BlogPostGetDTO>(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting blog post by slug: {Slug}", slug);
            return new ErrorReturn<BlogPostGetDTO>("Blog yazısı getirilirken hata oluştu.");
        }
    }
    
    public async Task<IReturn> PublishAsync(Guid id)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            var blogPost = await _repository.GetByIdAsync(id);
            if (blogPost == null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn("Blog yazısı bulunamadı.", 404);
            }
            
            if (blogPost.IsPublished)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn("Blog yazısı zaten yayınlanmış.", 400);
            }
            
            // Business rules for publishing
            if (string.IsNullOrEmpty(blogPost.Title) || string.IsNullOrEmpty(blogPost.Content))
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn("Başlık ve içerik dolu olmalıdır.", 400);
            }
            
            blogPost.IsPublished = true;
            blogPost.PublishedDate = DateTime.UtcNow;
            
            await _repository.UpdateAsync(blogPost);
            
            // Send notification email (fire and forget)
            _ = Task.Run(async () =>
            {
                try
                {
                    await _emailService.SendBlogPostPublishedNotificationAsync(blogPost);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending blog post published notification email");
                }
            });
            
            await _unitOfWork.CommitTransactionAsync();
            
            _logger.LogInformation("Blog post published: {Id}", id);
            
            return new SuccessReturn("Blog yazısı başarıyla yayınlandı.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error publishing blog post: {Id}", id);
            return new ErrorReturn("Blog yazısı yayınlanırken hata oluştu.");
        }
    }
    
    public async Task<IReturn> IncrementViewCountAsync(Guid id)
    {
        try
        {
            await _repository.IncrementViewCountAsync(id);
            return new SuccessReturn();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error incrementing view count for blog post: {Id}", id);
            return new ErrorReturn("Görüntülenme sayısı artırılırken hata oluştu.");
        }
    }
    
    protected override async Task<IReturn> ValidateForAddAsync<TAddDTO>(BlogPost entity, TAddDTO dto)
    {
        if (dto is BlogPostAddDTO addDto)
        {
            // Check if title is unique
            var existsWithTitle = await _repository.ExistsByTitleAsync(entity.Title);
            if (existsWithTitle)
                return new ErrorReturn("Bu başlıkta bir yazı zaten mevcut.");
            
            // Validate categories
            if (addDto.CategoryIds?.Any() == true)
            {
                foreach (var categoryId in addDto.CategoryIds)
                {
                    var categoryExists = await _categoryService.ExistsAsync(categoryId);
                    if (!categoryExists)
                        return new ErrorReturn($"Geçersiz kategori ID: {categoryId}");
                }
            }
            
            // Validate tags
            if (addDto.TagIds?.Any() == true)
            {
                foreach (var tagId in addDto.TagIds)
                {
                    var tagExists = await _tagService.ExistsAsync(tagId);
                    if (!tagExists)
                        return new ErrorReturn($"Geçersiz etiket ID: {tagId}");
                }
            }
        }
        
        return new SuccessReturn();
    }
    
    protected override async Task PostAddProcessingAsync<TAddDTO>(BlogPost entity, TAddDTO dto)
    {
        if (dto is BlogPostAddDTO addDto)
        {
            // Add categories
            if (addDto.CategoryIds?.Any() == true)
            {
                foreach (var categoryId in addDto.CategoryIds)
                {
                    await _repository.AddBlogPostCategoryAsync(entity.Id, categoryId);
                }
            }
            
            // Add tags
            if (addDto.TagIds?.Any() == true)
            {
                foreach (var tagId in addDto.TagIds)
                {
                    await _repository.AddBlogPostTagAsync(entity.Id, tagId);
                }
            }
        }
    }
    
    protected override async Task<IReturn> ValidateForDeleteAsync(BlogPost entity)
    {
        // Check if blog post has approved comments
        var hasComments = await _repository.HasApprovedCommentsAsync(entity.Id);
        if (hasComments)
        {
            return new ErrorReturn("Onaylanmış yorumları olan yazılar silinemez.");
        }
        
        return new SuccessReturn();
    }
}
```

### UserDatabaseService.cs

Kullanıcı işlemleri için özel business logic.

```csharp
public interface IUserDatabaseService : IDatabaseService<User>
{
    Task<IReturn<UserGetDTO>> AuthenticateAsync(UserLoginDTO loginDto);
    Task<IReturn<UserGetDTO>> RegisterAsync(UserRegisterDTO registerDto);
    Task<IReturn> ChangePasswordAsync(Guid userId, ChangePasswordDTO dto);
    Task<IReturn> ResetPasswordAsync(string email);
    Task<IReturn> ConfirmEmailAsync(Guid userId, string token);
    Task<IReturn<UserGetDTO>> GetByEmailAsync(string email);
    Task<IReturn> UpdateLastLoginAsync(Guid userId);
}

public class UserDatabaseService : DatabaseService<User, IUserRepository>, IUserDatabaseService
{
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;
    
    public UserDatabaseService(
        IUserRepository repository,
        IMapper mapper,
        ILogger<UserDatabaseService> logger,
        IUnitOfWork unitOfWork,
        IPasswordManager passwordManager,
        ITokenService tokenService,
        IEmailService emailService)
        : base(repository, mapper, logger, unitOfWork)
    {
        _passwordManager = passwordManager;
        _tokenService = tokenService;
        _emailService = emailService;
    }
    
    public async Task<IReturn<UserGetDTO>> AuthenticateAsync(UserLoginDTO loginDto)
    {
        try
        {
            var user = await _repository.GetByEmailAsync(loginDto.Email);
            
            if (user == null)
                return new ErrorReturn<UserGetDTO>("Geçersiz e-posta veya şifre.", 401);
            
            if (!user.IsActive)
                return new ErrorReturn<UserGetDTO>("Hesabınız devre dışı bırakılmış.", 401);
            
            if (!user.EmailConfirmed)
                return new ErrorReturn<UserGetDTO>("E-posta adresinizi onaylayın.", 401);
            
            var isPasswordValid = _passwordManager.VerifyPassword(loginDto.Password, user.PasswordHash);
            if (!isPasswordValid)
                return new ErrorReturn<UserGetDTO>("Geçersiz e-posta veya şifre.", 401);
            
            // Update last login
            await UpdateLastLoginAsync(user.Id);
            
            var userDto = _mapper.Map<UserGetDTO>(user);
            
            _logger.LogInformation("User authenticated successfully: {Email}", loginDto.Email);
            
            return new SuccessReturn<UserGetDTO>(userDto, "Giriş başarılı.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error authenticating user: {Email}", loginDto.Email);
            return new ErrorReturn<UserGetDTO>("Giriş sırasında bir hata oluştu.");
        }
    }
    
    public async Task<IReturn<UserGetDTO>> RegisterAsync(UserRegisterDTO registerDto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            // Check if email already exists
            var existingUser = await _repository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn<UserGetDTO>("Bu e-posta adresi zaten kullanılıyor.", 409);
            }
            
            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = _passwordManager.HashPassword(registerDto.Password);
            user.EmailConfirmed = false;
            user.IsActive = true;
            
            var createdUser = await _repository.AddAsync(user);
            
            // Generate email confirmation token
            var confirmationToken = _tokenService.GenerateEmailConfirmationToken(createdUser.Id);
            
            // Send confirmation email (fire and forget)
            _ = Task.Run(async () =>
            {
                try
                {
                    await _emailService.SendEmailConfirmationAsync(createdUser.Email, confirmationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending email confirmation");
                }
            });
            
            await _unitOfWork.CommitTransactionAsync();
            
            var userDto = _mapper.Map<UserGetDTO>(createdUser);
            
            _logger.LogInformation("User registered successfully: {Email}", registerDto.Email);
            
            return new SuccessReturn<UserGetDTO>(userDto, "Kayıt başarılı. E-posta onay linkini kontrol edin.", 201);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error registering user: {Email}", registerDto.Email);
            return new ErrorReturn<UserGetDTO>("Kayıt sırasında bir hata oluştu.");
        }
    }
    
    public async Task<IReturn> ChangePasswordAsync(Guid userId, ChangePasswordDTO dto)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn("Kullanıcı bulunamadı.", 404);
            }
            
            // Verify current password
            var isCurrentPasswordValid = _passwordManager.VerifyPassword(dto.CurrentPassword, user.PasswordHash);
            if (!isCurrentPasswordValid)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new ErrorReturn("Mevcut şifre yanlış.", 400);
            }
            
            // Hash new password
            user.PasswordHash = _passwordManager.HashPassword(dto.NewPassword);
            user.UpdatedDate = DateTime.UtcNow;
            
            await _repository.UpdateAsync(user);
            
            await _unitOfWork.CommitTransactionAsync();
            
            _logger.LogInformation("Password changed for user: {UserId}", userId);
            
            return new SuccessReturn("Şifre başarıyla değiştirildi.");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error changing password for user: {UserId}", userId);
            return new ErrorReturn("Şifre değiştirilirken hata oluştu.");
        }
    }
    
    public async Task<IReturn> UpdateLastLoginAsync(Guid userId)
    {
        try
        {
            await _repository.UpdateLastLoginAsync(userId, DateTime.UtcNow);
            return new SuccessReturn();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating last login for user: {UserId}", userId);
            return new ErrorReturn("Son giriş tarihi güncellenirken hata oluştu.");
        }
    }
    
    protected override async Task<IReturn> ValidateForDeleteAsync(User entity)
    {
        // Check if user has blog posts
        var hasBlogPosts = await _repository.HasBlogPostsAsync(entity.Id);
        if (hasBlogPosts)
        {
            return new ErrorReturn("Blog yazıları olan kullanıcılar silinemez.");
        }
        
        return new SuccessReturn();
    }
}
```

## Unit of Work Pattern

```csharp
public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<int> SaveChangesAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly TahaMucasirogluBlogContext _context;
    private IDbContextTransaction _transaction;
    
    public UnitOfWork(TahaMucasirogluBlogContext context)
    {
        _context = context;
    }
    
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }
    
    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
    
    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _transaction?.Dispose();
        _context?.Dispose();
    }
}
```

## Dependency Injection Configuration

```csharp
public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
    {
        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // Database Services
        services.AddScoped<IBlogPostDatabaseService, BlogPostDatabaseService>();
        services.AddScoped<IUserDatabaseService, UserDatabaseService>();
        services.AddScoped<ICategoryDatabaseService, CategoryDatabaseService>();
        services.AddScoped<ITagDatabaseService, TagDatabaseService>();
        services.AddScoped<ICommentDatabaseService, CommentDatabaseService>();
        services.AddScoped<IExperienceDatabaseService, ExperienceDatabaseService>();
        services.AddScoped<ISkillDatabaseService, SkillDatabaseService>();
        services.AddScoped<ISocialLinkDatabaseService, SocialLinkDatabaseService>();
        services.AddScoped<IInfoDatabaseService, InfoDatabaseService>();
        
        return services;
    }
}
```

## Best Practices

1. **Transaction Management**: Kritik işlemler için transaction kullanın
2. **Business Rules**: İş kurallarını service katmanında implement edin
3. **Validation**: Her operasyon öncesi validation yapın
4. **Logging**: Tüm işlemleri loglayın
5. **Error Handling**: Consistent error handling pattern kullanın
6. **Async Operations**: Tüm database işlemleri async olmalı
7. **Single Responsibility**: Her service tek sorumluluğa sahip olmalı