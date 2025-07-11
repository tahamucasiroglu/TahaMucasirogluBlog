using TahaMucasirogluBlog.Domain.Extensions;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager
{
    public class UrlManager : IUrlManager
    {
        public string BaseUrl { get; }
        public UrlManager(IConfiguration configuration)
        {
            string appsettingsUrl = configuration.GetAppSettingsValue("ApiSettings:ApiUrl");
            BaseUrl = appsettingsUrl.EndsWith("/") ? appsettingsUrl : appsettingsUrl + "/";
        }

        public string CheckLastSlash(string url) => url.EndsWith("/") ? url : url + "/";


        public string Build(string controller, string action, string route)
        {
            return BaseUrl + CheckLastSlash(controller) + CheckLastSlash(action) + (route.StartsWith("?") ? route : "?" + route);
        }

        public string Build(string controller, string action)
        {
            return BaseUrl + CheckLastSlash(controller) + CheckLastSlash(action);
        }

        public string Build(string endpoint)
        {
            return BaseUrl + CheckLastSlash(endpoint);
        }
    }
}
