using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class BlogPostApiConnectionService : Base.ApiConnectionService, IBlogPostApiConnectionService
    {
        public BlogPostApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<BlogPostApiConnectionService> logger) : base("BlogPost", urlManager, httpClient, logger)
        {
        }
    }
}
