# TahaMucasirogluBlog.Client - MVC Client Projeleri Dokümantasyonu

## Proje Amacı

Bu projeler, ASP.NET Core MVC kullanılarak geliştirilmiş web istemci uygulamalarını içerir. Her bir client farklı bir amaca hizmet eder ve API'ler üzerinden backend servisleriyle iletişim kurar.

## Client Projeleri

### 1. TahaMucasirogluBlog.Client.TahaMucasirogluMVC
Ana blog web sitesi - Genel kullanıcılara yönelik blog okuma ve etkileşim platformu

### 2. TahaMucasirogluBlog.Client.Admin.TahaMucasirogluMVC  
Admin paneli - Blog yönetimi, içerik moderasyonu ve sistem yönetimi

### 3. TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC
CV/Özgeçmiş sitesi - Profesyonel profil ve portfolio görüntüleme

## Ortak Proje Yapısı

```
TahaMucasirogluBlog.Client.*.TahaMucasirogluMVC/
├── Controllers/
│   ├── HomeController.cs
│   └── MaintenanceController.cs
├── Extensions/
│   ├── LoggerExtension.cs
│   ├── MiddlewaresExtension.cs
│   ├── MapperExtension.cs (Main site)
│   ├── ScopedExtension.cs
│   ├── SingletonExtension.cs
│   ├── ValidationExtension.cs (Main site)
│   └── JsonExtension.cs (Main site)
├── Managers/
├── Middlewares/
│   └── MaintenanceMiddleware.cs
├── Models/
│   └── ErrorViewModel.cs (Main site)
├── Options/
│   └── MaintenanceOption.cs
├── Services/
├── ViewComponents/ (Main site)
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml (Admin site)
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   └── favicon.ico
├── Program.cs
├── appsettings.json
└── appsettings.Development.json
```

## Ana Blog Sitesi (TahaMucasirogluMVC)

### Program.cs Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// Add HTTP client for API communication
builder.Services.AddHttpClient("BlogAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Add custom services
builder.Services.AddScopedServices();
builder.Services.AddSingletonServices();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddValidationServices();
builder.Services.AddLogging(builder.Configuration);

// Add session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Custom middlewares
app.UseMiddleware<MaintenanceMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// SEO friendly routes
app.MapControllerRoute(
    name: "blog-post",
    pattern: "blog/{slug}",
    defaults: new { controller = "Blog", action = "Details" });

app.MapControllerRoute(
    name: "category",
    pattern: "category/{slug}",
    defaults: new { controller = "Blog", action = "Category" });

app.Run();
```

### Controllers

#### HomeController.cs (Ana Site)

```csharp
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogService _blogService;
    private readonly ICacheService _cacheService;
    
    public HomeController(
        ILogger<HomeController> logger,
        IBlogService blogService,
        ICacheService cacheService)
    {
        _logger = logger;
        _blogService = blogService;
        _cacheService = cacheService;
    }
    
    public async Task<IActionResult> Index()
    {
        try
        {
            var viewModel = new HomeViewModel();
            
            // Get featured posts
            var featuredPosts = await _blogService.GetFeaturedPostsAsync(3);
            viewModel.FeaturedPosts = featuredPosts;
            
            // Get recent posts
            var recentPosts = await _blogService.GetRecentPostsAsync(6);
            viewModel.RecentPosts = recentPosts;
            
            // Get popular categories
            var categories = await _blogService.GetPopularCategoriesAsync(5);
            viewModel.PopularCategories = categories;
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading home page");
            return View("Error", new ErrorViewModel());
        }
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Contact()
    {
        return View(new ContactViewModel());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact(ContactViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        try
        {
            await _blogService.SendContactMessageAsync(model);
            TempData["Success"] = "Mesajınız başarıyla gönderildi.";
            return RedirectToAction(nameof(Contact));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending contact message");
            ModelState.AddModelError("", "Mesaj gönderilirken bir hata oluştu.");
            return View(model);
        }
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
```

#### BlogController.cs (Ana Site)

```csharp
public class BlogController : Controller
{
    private readonly IBlogService _blogService;
    private readonly ILogger<BlogController> _logger;
    
    public BlogController(IBlogService blogService, ILogger<BlogController> logger)
    {
        _blogService = blogService;
        _logger = logger;
    }
    
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        try
        {
            var posts = await _blogService.GetPagedPostsAsync(page, pageSize);
            var viewModel = new BlogIndexViewModel
            {
                Posts = posts.Items,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)posts.TotalCount / pageSize),
                TotalPosts = posts.TotalCount
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading blog index");
            return View("Error");
        }
    }
    
    [Route("blog/{slug}")]
    public async Task<IActionResult> Details(string slug)
    {
        try
        {
            var post = await _blogService.GetPostBySlugAsync(slug);
            
            if (post == null)
                return NotFound();
            
            // Increment view count
            await _blogService.IncrementViewCountAsync(post.Id);
            
            // Get related posts
            var relatedPosts = await _blogService.GetRelatedPostsAsync(post.Id, 3);
            
            var viewModel = new BlogDetailsViewModel
            {
                Post = post,
                RelatedPosts = relatedPosts,
                Comments = await _blogService.GetCommentsAsync(post.Id)
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading blog post: {Slug}", slug);
            return View("Error");
        }
    }
    
    [Route("category/{slug}")]
    public async Task<IActionResult> Category(string slug, int page = 1)
    {
        try
        {
            var category = await _blogService.GetCategoryBySlugAsync(slug);
            if (category == null)
                return NotFound();
            
            var posts = await _blogService.GetPostsByCategoryAsync(category.Id, page, 10);
            
            var viewModel = new BlogCategoryViewModel
            {
                Category = category,
                Posts = posts.Items,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)posts.TotalCount / 10)
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading category: {Slug}", slug);
            return View("Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Search(string q, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(q))
            return RedirectToAction(nameof(Index));
        
        try
        {
            var results = await _blogService.SearchPostsAsync(q, page, 10);
            
            var viewModel = new BlogSearchViewModel
            {
                SearchTerm = q,
                Posts = results.Items,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)results.TotalCount / 10),
                TotalResults = results.TotalCount
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching posts: {Query}", q);
            return View("Error");
        }
    }
}
```

### Services

#### IBlogService.cs ve BlogService.cs

```csharp
public interface IBlogService
{
    Task<List<BlogPostDTO>> GetFeaturedPostsAsync(int count);
    Task<List<BlogPostDTO>> GetRecentPostsAsync(int count);
    Task<PagedResult<BlogPostDTO>> GetPagedPostsAsync(int page, int pageSize);
    Task<BlogPostDTO> GetPostBySlugAsync(string slug);
    Task<List<CategoryDTO>> GetPopularCategoriesAsync(int count);
    Task IncrementViewCountAsync(Guid postId);
    Task<List<CommentDTO>> GetCommentsAsync(Guid postId);
    Task SendContactMessageAsync(ContactViewModel model);
}

public class BlogService : IBlogService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly ILogger<BlogService> _logger;
    private readonly ICacheService _cacheService;
    
    public BlogService(
        IHttpClientFactory httpClientFactory,
        IMapper mapper,
        ILogger<BlogService> logger,
        ICacheService cacheService)
    {
        _httpClient = httpClientFactory.CreateClient("BlogAPI");
        _mapper = mapper;
        _logger = logger;
        _cacheService = cacheService;
    }
    
    public async Task<List<BlogPostDTO>> GetFeaturedPostsAsync(int count)
    {
        var cacheKey = $"featured_posts_{count}";
        
        var cached = await _cacheService.GetAsync<List<BlogPostDTO>>(cacheKey);
        if (cached != null)
            return cached;
        
        try
        {
            var response = await _httpClient.GetAsync($"api/blogpost/featured?count={count}");
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            var posts = JsonSerializer.Deserialize<List<BlogPostDTO>>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            await _cacheService.SetAsync(cacheKey, posts, TimeSpan.FromMinutes(30));
            
            return posts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting featured posts");
            return new List<BlogPostDTO>();
        }
    }
    
    public async Task<BlogPostDTO> GetPostBySlugAsync(string slug)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/blogpost/by-slug/{slug}");
            
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            var post = JsonSerializer.Deserialize<BlogPostDTO>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            return post;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting post by slug: {Slug}", slug);
            return null;
        }
    }
    
    public async Task IncrementViewCountAsync(Guid postId)
    {
        try
        {
            await _httpClient.PatchAsync($"api/blogpost/{postId}/increment-view", null);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error incrementing view count for post: {PostId}", postId);
            // Don't throw - this is not critical
        }
    }
}
```

## CV Sitesi (Client.Cv.TahaMucasirogluMVC)

### CvController.cs

```csharp
public class CvController : Controller
{
    private readonly ICvService _cvService;
    private readonly ILogger<CvController> _logger;
    
    public CvController(ICvService cvService, ILogger<CvController> logger)
    {
        _cvService = cvService;
        _logger = logger;
    }
    
    public async Task<IActionResult> Index()
    {
        try
        {
            var cv = await _cvService.GetPublicCvAsync();
            
            if (cv == null)
            {
                return View("CvNotFound");
            }
            
            var viewModel = new CvViewModel
            {
                PersonalInfo = cv.PersonalInfo,
                Experiences = cv.Experiences,
                Skills = cv.Skills,
                SocialLinks = cv.SocialLinks,
                LastUpdated = cv.LastUpdated
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading CV");
            return View("Error");
        }
    }
    
    public async Task<IActionResult> Download()
    {
        try
        {
            var pdfBytes = await _cvService.ExportToPdfAsync();
            
            if (pdfBytes == null || pdfBytes.Length == 0)
            {
                TempData["Error"] = "CV PDF oluşturulamadı.";
                return RedirectToAction(nameof(Index));
            }
            
            var fileName = $"TahaMucasiroglu_CV_{DateTime.Now:yyyyMMdd}.pdf";
            return File(pdfBytes, "application/pdf", fileName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error downloading CV PDF");
            TempData["Error"] = "PDF indirme sırasında bir hata oluştu.";
            return RedirectToAction(nameof(Index));
        }
    }
}
```

## Admin Paneli (Client.Admin.TahaMucasirogluMVC)

### AdminController.cs

```csharp
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IBlogService _blogService;
    private readonly IUserService _userService;
    private readonly ILogger<AdminController> _logger;
    
    public AdminController(
        IBlogService blogService,
        IUserService userService,
        ILogger<AdminController> logger)
    {
        _blogService = blogService;
        _userService = userService;
        _logger = logger;
    }
    
    public async Task<IActionResult> Dashboard()
    {
        try
        {
            var viewModel = new AdminDashboardViewModel
            {
                TotalPosts = await _blogService.GetTotalPostsCountAsync(),
                PublishedPosts = await _blogService.GetPublishedPostsCountAsync(),
                DraftPosts = await _blogService.GetDraftPostsCountAsync(),
                TotalUsers = await _userService.GetTotalUsersCountAsync(),
                RecentPosts = await _blogService.GetRecentPostsAsync(5),
                PendingComments = await _blogService.GetPendingCommentsCountAsync()
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading admin dashboard");
            return View("Error");
        }
    }
    
    public async Task<IActionResult> Posts(int page = 1)
    {
        try
        {
            var posts = await _blogService.GetAllPostsAsync(page, 20);
            
            var viewModel = new AdminPostsViewModel
            {
                Posts = posts.Items,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)posts.TotalCount / 20)
            };
            
            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading admin posts");
            return View("Error");
        }
    }
}
```

## Middlewares

### MaintenanceMiddleware.cs

```csharp
public class MaintenanceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly ILogger<MaintenanceMiddleware> _logger;
    
    public MaintenanceMiddleware(
        RequestDelegate next,
        IConfiguration configuration,
        ILogger<MaintenanceMiddleware> logger)
    {
        _next = next;
        _configuration = configuration;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var maintenanceMode = _configuration.GetValue<bool>("MaintenanceMode:Enabled");
        
        if (maintenanceMode)
        {
            var allowedIPs = _configuration.GetSection("MaintenanceMode:AllowedIPs").Get<string[]>();
            var clientIP = context.Connection.RemoteIpAddress?.ToString();
            
            // Allow specific IPs during maintenance
            if (allowedIPs != null && allowedIPs.Contains(clientIP))
            {
                await _next(context);
                return;
            }
            
            // Allow maintenance page access
            if (context.Request.Path.StartsWithSegments("/maintenance"))
            {
                await _next(context);
                return;
            }
            
            _logger.LogInformation("Maintenance mode redirect for IP: {ClientIP}", clientIP);
            context.Response.Redirect("/maintenance");
            return;
        }
        
        await _next(context);
    }
}
```

## View Models

### HomeViewModel.cs

```csharp
public class HomeViewModel
{
    public List<BlogPostDTO> FeaturedPosts { get; set; } = new();
    public List<BlogPostDTO> RecentPosts { get; set; } = new();
    public List<CategoryDTO> PopularCategories { get; set; } = new();
    public List<TagDTO> PopularTags { get; set; } = new();
    public SiteStatsDTO SiteStats { get; set; }
}
```

### CvViewModel.cs

```csharp
public class CvViewModel
{
    public PersonalInfoDTO PersonalInfo { get; set; }
    public List<ExperienceDTO> Experiences { get; set; } = new();
    public List<SkillCategoryDTO> Skills { get; set; } = new();
    public List<SocialLinkDTO> SocialLinks { get; set; } = new();
    public DateTime LastUpdated { get; set; }
    public string Theme { get; set; } = "default";
}
```

## Configuration

### appsettings.json (örnek)

```json
{
  "ApiSettings": {
    "BaseUrl": "https://api.tahamucasiroglu.com/"
  },
  "MaintenanceMode": {
    "Enabled": false,
    "AllowedIPs": [ "127.0.0.1", "::1" ],
    "Message": "Site bakımda. Lütfen daha sonra tekrar deneyin."
  },
  "Cache": {
    "DefaultExpirationMinutes": 30,
    "SlidingExpirationMinutes": 10
  },
  "SEO": {
    "SiteName": "Taha Mucasiroğlu Blog",
    "DefaultDescription": "Yazılım geliştirme, teknoloji ve kişisel deneyimler hakkında blog",
    "DefaultKeywords": "yazılım,teknoloji,blog,programming"
  }
}
```

## Best Practices

1. **Separation of Concerns**: Her client kendi sorumluluğunda kalmalı
2. **API Communication**: HTTP client'ları dependency injection ile yönetin
3. **Error Handling**: Global exception handling middleware kullanın
4. **Caching**: Frequently accessed data için caching stratejisi uygulayın
5. **SEO Optimization**: Meta tags, URL structure ve sitemap optimize edin
6. **Responsive Design**: Mobile-first yaklaşım benimseyin
7. **Security**: CSRF, XSS ve diğer güvenlik önlemlerini alın
8. **Performance**: Bundle optimization ve lazy loading kullanın