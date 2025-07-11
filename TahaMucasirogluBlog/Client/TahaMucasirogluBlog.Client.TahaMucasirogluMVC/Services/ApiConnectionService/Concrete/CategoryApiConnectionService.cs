using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class CategoryApiConnectionService : Base.ApiConnectionService, ICategoryApiConnectionService
    {
        public CategoryApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<CategoryApiConnectionService> logger) : base("Category", urlManager, httpClient, logger)
        {
        }
    }
}
