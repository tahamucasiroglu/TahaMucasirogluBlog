using TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Middlewares;

namespace TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Extensions
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
