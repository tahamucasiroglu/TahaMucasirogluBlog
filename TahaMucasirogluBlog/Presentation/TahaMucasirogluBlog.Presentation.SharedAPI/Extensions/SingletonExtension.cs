using TahaMucasirogluBlog.Application.Managers.PasswordManager;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Extensions
{
    static public class SingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
