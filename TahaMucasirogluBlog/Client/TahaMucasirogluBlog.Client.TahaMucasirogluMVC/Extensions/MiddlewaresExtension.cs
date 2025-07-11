using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Middlewares;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Extensions
{
    static public class MiddlewaresExtension
    {
        static public void AddMiddlewares(this WebApplication app)
        {
            //app.UseMiddleware<>();
            app.UseMiddleware<ArgumentNullExceptionMiddleware>();
            app.UseMiddleware<MaintenanceMiddleware>();

        }
    }
}
