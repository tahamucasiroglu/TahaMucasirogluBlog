using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract.Base;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class BlogPostTagApiConnectionService : Base.ApiConnectionService, IBlogPostTagApiConnectionService
    {
        public BlogPostTagApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<BlogPostTagApiConnectionService> logger) : base("BlogPostTag", urlManager, httpClient, logger)
        {
        }
    }
}
