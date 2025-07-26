using Microsoft.AspNetCore.Builder;
using TahaMucasiroglu.Client.MVC.Middlewares;

namespace TahaMucasiroglu.Client.MVC.Extensions
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
