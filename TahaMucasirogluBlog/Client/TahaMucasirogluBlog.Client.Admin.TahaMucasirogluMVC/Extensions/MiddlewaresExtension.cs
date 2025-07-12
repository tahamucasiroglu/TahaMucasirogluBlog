using TahaMucasirogluBlog.Client.Admin.TahaMucasirogluMVC.Middlewares;

namespace TahaMucasirogluBlog.Client.Admin.TahaMucasirogluMVC.Extensions
{
    static public class MiddlewaresExtension
    {
        static public void AddMiddlewares(this WebApplication app)
        {
            //app.UseMiddleware<>();
            app.UseMiddleware<MaintenanceMiddleware>();

        }
    }
}
