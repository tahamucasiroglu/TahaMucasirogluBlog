using TahaMucasirogluBlog.Presentation.API.Middlewares;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Extensions
{
    static public class AddMiddlewaresExtension
    {
        static public void AddMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

        }
    }
}
