# TahaMucasirogluBlog.Infrastructure.Repository - Repository Projesi Dokümantasyonu

## Proje Amacı

Bu proje, Entity Framework Core kullanarak veri erişim katmanını (Data Access Layer) yöneten repository pattern implementasyonlarını içerir. Veritabanı işlemlerini soyutlar ve Domain katmanının veritabanı detaylarından bağımsız kalmasını sağlar.

## Proje Yapısı

```
TahaMucasirogluBlog.Infrastructure.Repository/
├── Configuration/
│   ├── BlogPostCategoryConfiguration.cs
│   ├── BlogPostConfiguration.cs
│   ├── BlogPostTagConfiguration.cs
│   ├── CategoryConfiguration.cs
│   ├── CommentConfiguration.cs
│   ├── ExperienceConfiguration.cs
│   ├── ExperienceTechnologyConfiguration.cs
│   ├── ExperienceType.cs
│   ├── InfoConfiguration.cs
│   ├── SkillConfiguration.cs
│   ├── SocialLinkConfiguration.cs
│   ├── SubSkillConfiguration.cs
│   ├── TagConfiguration.cs
│   └── UserConfiguration.cs
├── Context/
│   └── TahaMucasirogluBlogContext.cs
├── Migrations/
│   ├── 20250712182652_AutoMig_2025_7_12_21_26_47.Designer.cs
│   ├── 20250712182652_AutoMig_2025_7_12_21_26_47.cs
│   └── TahaMucasirogluBlogContextModelSnapshot.cs
└── Repository/
    ├── Abstract/
    │   ├── Base/
    │   │   └── IRepository.cs
    │   ├── IBlogPostCategoryRepository.cs
    │   ├── IBlogPostRepository.cs
    │   ├── IBlogPostTagRepository.cs
    │   ├── ICategoryRepository.cs
    │   ├── ICommentRepository.cs
    │   ├── IExperienceRepository.cs
    │   ├── IExperienceTechnologyRepository.cs
    │   ├── IExperienceTypeRepository.cs
    │   ├── IInfoRepository.cs
    │   ├── ISkillRepository.cs
    │   ├── ISocialLinkRepository.cs
    │   ├── ISubSkillRepository.cs
    │   ├── ITagRepository.cs
    │   └── IUserRepository.cs
    ├── Base/
    │   └── Repository.cs
    └── Concrete/
        ├── BlogPostCategoryRepository.cs
        ├── BlogPostRepository.cs
        ├── BlogPostTagRepository.cs
        ├── CategoryRepository.cs
        ├── CommentRepository.cs
        ├── ExperienceRepository.cs
        ├── ExperienceTechnologyRepository.cs
        ├── ExperienceTypeRepository.cs
        ├── InfoRepository.cs
        ├── SkillRepository.cs
        ├── SocialLinkRepository.cs
        ├── SubSkillRepository.cs
        ├── TagRepository.cs
        └── UserRepository.cs
```

## Repository Pattern Architecture

### Base Repository Layer

#### IRepository<TEntity> Interface

Generic repository interface'i - tüm CRUD operasyonları ve gelişmiş özelliklerle.

```csharp
public interface IRepository<TEntity> : IDisposable, IAsyncDisposable where TEntity : class, IEntity
{
    // Include Operations
    IReturn<TEntity> GetWithIncludes(Guid id, params Expression<Func<TEntity, object>>[] includes);
    Task<IReturn<TEntity>> GetWithIncludesAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
    IReturn<List<TEntity>> GetAllWithIncludes(params Expression<Func<TEntity, object>>[] includes);
    Task<IReturn<List<TEntity>>> GetAllWithIncludesAsync(params Expression<Func<TEntity, object>>[] includes);
    
    // Basic CRUD Operations
    IReturn<TEntity> Add(TEntity entity);
    Task<IReturn<TEntity>> AddAsync(TEntity entity);
    IReturn<TEntity> Update(TEntity entity);
    Task<IReturn<TEntity>> UpdateAsync(TEntity entity);
    IReturn<TEntity> Delete(TEntity entity);
    Task<IReturn<TEntity>> DeleteAsync(TEntity entity);
    IReturn<TEntity> Get(Guid id);
    Task<IReturn<TEntity>> GetAsync(Guid id);
    IReturn<List<TEntity>> GetAll();
    Task<IReturn<List<TEntity>>> GetAllAsync();
    
    // Soft Delete Operations
    IReturn<TEntity> GetDeleted(Guid id);
    Task<IReturn<TEntity>> GetDeletedAsync(Guid id);
    IReturn<List<TEntity>> GetAllDeleted();
    Task<IReturn<List<TEntity>>> GetAllDeletedAsync();
    
    // Utility Operations
    IReturn<int> Count();
    Task<IReturn<int>> CountAsync();
    IReturn<bool> IsExist(Guid id);
    Task<IReturn<bool>> IsExistAsync(Guid id);
    IReturn<bool> Save();
    Task<IReturn<bool>> SaveAsync();
    
    // Transaction Management
    IReturn<bool> BeginTransaction();
    Task<IReturn<bool>> BeginTransactionAsync();
    IReturn<bool> Commit();
    Task<IReturn<bool>> CommitAsync();
    IReturn<bool> Rollback();
    Task<IReturn<bool>> RollbackAsync();
}
```

#### Repository<TEntity> Base Class

Abstract base repository implementasyonu:

```csharp
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly TahaMucasirogluBlogContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly ILogger<Repository<TEntity>> _logger;
    private IDbContextTransaction? _transaction;
    
    protected Repository(TahaMucasirogluBlogContext context, ILogger<Repository<TEntity>> logger)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _logger = logger;
    }
    
    // Include Operations Implementation
    public virtual IReturn<TEntity> GetWithIncludes(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            
            // Apply includes
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            
            var entity = query.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            
            if (entity == null)
                return new ErrorReturn<TEntity>("Entity not found");
            
            return new SuccessReturn<TEntity>(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting entity with includes");
            return new ErrorReturn<TEntity>("Error occurred while getting entity");
        }
    }
    
    // Async version
    public virtual async Task<IReturn<TEntity>> GetWithIncludesAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            
            var entity = await query.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            
            if (entity == null)
                return new ErrorReturn<TEntity>("Entity not found");
            
            return new SuccessReturn<TEntity>(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting entity with includes async");
            return new ErrorReturn<TEntity>("Error occurred while getting entity");
        }
    }
    
    // Basic CRUD Operations
    public virtual IReturn<TEntity> Add(TEntity entity)
    {
        try
        {
            entity.Id = Guid.NewGuid();
            entity.InsertedAt = DateTime.UtcNow;
            entity.IsDeleted = false;
            // entity.InsertedBy = GetCurrentUserId(); // Context'ten alınabilir
            
            _dbSet.Add(entity);
            
            return new SuccessReturn<TEntity>(entity, "Entity added successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding entity");
            return new ErrorReturn<TEntity>("Error occurred while adding entity");
        }
    }
    
    public virtual IReturn<TEntity> Update(TEntity entity)
    {
        try
        {
            entity.UpdatedAt = DateTime.UtcNow;
            // entity.UpdatedBy = GetCurrentUserId();
            
            _dbSet.Update(entity);
            
            return new SuccessReturn<TEntity>(entity, "Entity updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating entity");
            return new ErrorReturn<TEntity>("Error occurred while updating entity");
        }
    }
    
    public virtual IReturn<TEntity> Delete(TEntity entity)
    {
        try
        {
            // Soft delete implementation
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            // entity.DeletedBy = GetCurrentUserId();
            
            _dbSet.Update(entity);
            
            return new SuccessReturn<TEntity>(entity, "Entity deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting entity");
            return new ErrorReturn<TEntity>("Error occurred while deleting entity");
        }
    }
    
    public virtual IReturn<TEntity> Get(Guid id)
    {
        try
        {
            var entity = _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            
            if (entity == null)
                return new ErrorReturn<TEntity>("Entity not found");
            
            return new SuccessReturn<TEntity>(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting entity by id");
            return new ErrorReturn<TEntity>("Error occurred while getting entity");
        }
    }
    
    public virtual IReturn<List<TEntity>> GetAll()
    {
        try
        {
            var entities = _dbSet.AsNoTracking().Where(x => !x.IsDeleted).ToList();
            return new SuccessReturn<List<TEntity>>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all entities");
            return new ErrorReturn<List<TEntity>>("Error occurred while getting entities");
        }
    }
    
    // Soft Delete Operations
    public virtual IReturn<TEntity> GetDeleted(Guid id)
    {
        try
        {
            var entity = _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && x.IsDeleted);
            
            if (entity == null)
                return new ErrorReturn<TEntity>("Deleted entity not found");
            
            return new SuccessReturn<TEntity>(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting deleted entity");
            return new ErrorReturn<TEntity>("Error occurred while getting deleted entity");
        }
    }
    
    // Transaction Management
    public virtual IReturn<bool> BeginTransaction()
    {
        try
        {
            _transaction = _context.Database.BeginTransaction();
            return new SuccessReturn<bool>(true, "Transaction started");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error beginning transaction");
            return new ErrorReturn<bool>("Error starting transaction");
        }
    }
    
    public virtual IReturn<bool> Commit()
    {
        try
        {
            _transaction?.Commit();
            return new SuccessReturn<bool>(true, "Transaction committed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error committing transaction");
            return new ErrorReturn<bool>("Error committing transaction");
        }
    }
    
    public virtual IReturn<bool> Save()
    {
        try
        {
            _context.SaveChanges();
            return new SuccessReturn<bool>(true, "Changes saved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving changes");
            return new ErrorReturn<bool>("Error saving changes");
        }
    }
    
    // Async versions of all methods...
    // (Implementation follows same pattern with async/await)
    
    public void Dispose()
    {
        _transaction?.Dispose();
        _context?.Dispose();
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_transaction != null)
            await _transaction.DisposeAsync();
        
        if (_context != null)
            await _context.DisposeAsync();
    }
}
```

### Entity-Specific Repository Layer

#### Repository Interfaces

Her entity için basit interface (şu anda boş, gelecekte özel metodlar eklenebilir):

```csharp
public interface IBlogPostRepository : IRepository<BlogPost>
{
    // Entity-specific methods can be added here
}

public interface IExperienceRepository : IRepository<Experience>
{
    // Entity-specific methods can be added here
}

public interface ISkillRepository : IRepository<Skill>
{
    // Entity-specific methods can be added here
}

// ... diğer entity repository interface'leri
```

#### Repository Implementations

Her entity için concrete repository implementasyonu:

```csharp
public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
{
    public BlogPostRepository(TahaMucasirogluBlogContext context, ILogger<BlogPostRepository> logger) 
        : base(context, logger)
    {
    }
    
    // Entity-specific methods can be implemented here
}

public class ExperienceRepository : Repository<Experience>, IExperienceRepository
{
    public ExperienceRepository(TahaMucasirogluBlogContext context, ILogger<ExperienceRepository> logger) 
        : base(context, logger)
    {
    }
}

public class SkillRepository : Repository<Skill>, ISkillRepository
{
    public SkillRepository(TahaMucasirogluBlogContext context, ILogger<SkillRepository> logger) 
        : base(context, logger)
    {
    }
}

// ... diğer repository implementasyonları
```

## Entity Base Structure

### IEntity Interface

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

### Entity Base Class

```csharp
public abstract class Entity : IEntity
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

## Database Context

### TahaMucasirogluBlogContext.cs

```csharp
public class TahaMucasirogluBlogContext : DbContext
{
    public TahaMucasirogluBlogContext(DbContextOptions<TahaMucasirogluBlogContext> options) 
        : base(options)
    {
    }
    
    // DbSets - Entity Collections
    public DbSet<User> Users { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<BlogPostCategory> BlogPostCategories { get; set; }
    public DbSet<BlogPostTag> BlogPostTags { get; set; }
    
    // CV Entities
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<ExperienceType> ExperienceTypes { get; set; }
    public DbSet<ExperienceTechnology> ExperienceTechnologies { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SubSkill> SubSkills { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<Info> Infos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply all configurations from Configuration folder
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TahaMucasirogluBlogContext).Assembly);
    }
}
```

## Key Features

### 1. Soft Delete Implementation
- Entities are marked as deleted (`IsDeleted = true`) rather than physically removed
- Separate methods for accessing deleted entities (`GetDeleted`, `GetAllDeleted`)

### 2. Audit Trail
- Automatic tracking of `InsertedAt`, `UpdatedAt`, `DeletedAt`
- User tracking with `InsertedBy`, `UpdatedBy`, `DeletedBy`

### 3. Include Support
- `GetWithIncludes` and `GetAllWithIncludes` methods for eager loading
- Support for multiple navigation properties

### 4. Transaction Management
- Built-in transaction support with `BeginTransaction`, `Commit`, `Rollback`
- Proper disposal pattern implementation

### 5. Async Support
- Full async/await pattern implementation for all operations
- `IAsyncDisposable` support

### 6. Error Handling
- Custom `IReturn<T>` pattern instead of exceptions
- Structured logging integration

### 7. Performance Optimization
- `AsNoTracking()` for read operations
- Efficient query building

## Return Type System

```csharp
public interface IReturn<T>
{
    bool IsSuccess { get; }
    string Message { get; }
    T Data { get; }
}

public class SuccessReturn<T> : IReturn<T>
{
    public bool IsSuccess => true;
    public string Message { get; set; }
    public T Data { get; set; }
}

public class ErrorReturn<T> : IReturn<T>
{
    public bool IsSuccess => false;
    public string Message { get; set; }
    public T Data => default(T);
}
```

## Usage Examples

### Basic CRUD Operations

```csharp
// Get entity by ID
var result = await _blogPostRepository.GetAsync(id);
if (result.IsSuccess)
{
    var blogPost = result.Data;
}

// Get with includes
var result = await _experienceRepository.GetWithIncludesAsync(id, 
    x => x.ExperienceType, 
    x => x.ExperienceTechnologies);
```

### Transaction Usage

```csharp
var transaction = await _repository.BeginTransactionAsync();
try
{
    await _repository.AddAsync(entity1);
    await _repository.SaveAsync();
    
    await _repository.AddAsync(entity2);
    await _repository.SaveAsync();
    
    await _repository.CommitAsync();
}
catch
{
    await _repository.RollbackAsync();
    throw;
}
```

## Best Practices

1. **Generic Pattern**: Kod tekrarını önlemek için generic base repository
2. **Soft Delete**: Fiziksel silme yerine soft delete
3. **Audit Trail**: Tüm işlemlerde kullanıcı ve zaman takibi
4. **Async Operations**: Performance için async/await pattern
5. **Include Strategy**: Gerektiğinde eager loading
6. **Transaction Management**: Consistency için transaction support
7. **Error Handling**: Exception fırlatmak yerine structured return types
8. **Logging**: Structured logging ile traceability