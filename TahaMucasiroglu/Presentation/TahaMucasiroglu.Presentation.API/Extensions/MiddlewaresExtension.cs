using Microsoft.AspNetCore.Builder;
using TahaMucasiroglu.Presentation.API.Middlewares;

namespace TahaMucasiroglu.Presentation.API.Extensions
{
    static public class AddMiddlewaresExtension
    {
        static public void AddMiddlewares(
            this WebApplication app, 
            bool ErrorHandlingMiddleware = true, 
            bool NotFoundMiddleware = true)
        {
            if(ErrorHandlingMiddleware) app.UseMiddleware<ErrorHandlingMiddleware>();
            if(NotFoundMiddleware) app.UseMiddleware<NotFoundMiddleware>();

        }
    }
}
