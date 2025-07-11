using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class BlogPostCategoryApiConnectionService : Base.ApiConnectionService, IBlogPostCategoryApiConnectionService
    {
        public BlogPostCategoryApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<BlogPostCategoryApiConnectionService> logger) : base("BlogPostCategory", urlManager, httpClient, logger)
        {
        }
    }
}
