using TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Managers.UrlManager;

namespace TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Extensions
{
    static public class SingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IUrlManager, UrlManager>();
            builder.Services.AddHttpContextAccessor();
        }
    }
}
