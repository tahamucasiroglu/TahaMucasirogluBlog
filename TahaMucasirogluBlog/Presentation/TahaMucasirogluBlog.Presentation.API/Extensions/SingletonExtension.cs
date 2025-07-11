using TahaMucasirogluBlog.Application.Managers.PasswordManager;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    static public class SingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<IPasswordManager, PasswordManager>();
        }
    }
}
