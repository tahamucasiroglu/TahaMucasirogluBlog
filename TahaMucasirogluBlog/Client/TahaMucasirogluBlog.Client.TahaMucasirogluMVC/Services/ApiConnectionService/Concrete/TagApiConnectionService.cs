using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class TagApiConnectionService : Base.ApiConnectionService, ITagApiConnectionService
    {
        public TagApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<TagApiConnectionService> logger) : base("Tag", urlManager, httpClient, logger)
        {
        }
    }
}
