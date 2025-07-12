using Microsoft.Extensions.Options;
using TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Options;

namespace TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC.Middlewares
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate next;
        private readonly MaintenanceOption options;
        private readonly ILogger<MaintenanceMiddleware> logger;

        public MaintenanceMiddleware(
            RequestDelegate next,
            IOptions<MaintenanceOption> options,
            ILogger<MaintenanceMiddleware> logger)
        {
            this.next = next;
            this.options = options.Value;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Sadece bakım modu aktifse ve istek kendisi bakım sayfasına değilse
            if (this.options.Enabled
                && DateTime.Now < this.options.EndDateTime
                && !context.Request.Path.StartsWithSegments("/Maintenance"))
            {
                this.logger.LogInformation(
                    "Bakım modu {EndDateTime} tarihine kadar aktif. {Method} isteği {Path}{QueryString} yolundan, {RemoteIpAddress} IP adresinden bakım sayfasına yönlendiriliyor.",
                    this.options.EndDateTime,
                    context.Request.Method,
                    context.Request.Path,
                    context.Request.QueryString,
                    context.Connection.RemoteIpAddress);

                context.Response.Redirect("/Maintenance");
                return;
            }

            await this.next(context);
        }
    }
}
