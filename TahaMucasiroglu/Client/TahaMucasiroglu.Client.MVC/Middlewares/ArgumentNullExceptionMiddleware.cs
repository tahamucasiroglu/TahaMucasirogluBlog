using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TahaMucasiroglu.Client.MVC.Middlewares
{
    public class ArgumentNullExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ArgumentNullExceptionMiddleware> logger;

        public ArgumentNullExceptionMiddleware(
            RequestDelegate next,
            ILogger<ArgumentNullExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ArgumentNullException ex)
            {
                logger.LogError(ex,
                    "ErrorCode: 8b4a7ae7-efb3-4dd3-a2a7-cc80b1e20ce2 \nArgumentNullException: {Message} \nPath: {Path}",
                    ex.Message,
                    context.Request.Path);

                context.Response.Redirect("/Error/ArgumentNull");
            }
        }
    }
}
