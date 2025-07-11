using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete
{
    public class UserApiConnectionService : Base.ApiConnectionService, IUserApiConnectionService
    {
        public UserApiConnectionService(IUrlManager urlManager, HttpClient httpClient, ILogger<UserApiConnectionService> logger) : base("User", urlManager, httpClient, logger)
        {
        }
    }
}
