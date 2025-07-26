using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Presentation.API.Extensions
{
    public static class CorsExtension
    {

        static public void SetCors(this WebApplication app)
        {
            string CorsName = app.Configuration.GetCORSNameAppSettings();
            app.UseCors(CorsName);
        }



        static public void SetCors(this WebApplicationBuilder builder, Serilog.ILogger? logger = null, string? spliter = null)
        {
            string CorsName = builder.Configuration.GetCORSNameAppSettings();
            string CorsURLsString = builder.Configuration.GetCorsURLsAppSettings();
            string[] CorsUrls = CorsURLsString.Split(spliter ?? " ");
            bool AnyCors = builder.Configuration.GetAnyCorsAppSettings();

            if(logger != null)
            {
                logger.Information($@"
CorsName = {CorsName}
CorsURLsString = {CorsURLsString}
CorsUrls = {CorsUrls}
");
            }

            if (AnyCors) builder.SetAnyCors(corsName: CorsName);
            else builder.SetUrlCors(CorsName, CorsUrls);







        }
        static public void SetUrlCors(this WebApplicationBuilder builder, string corsName, params string[] origins)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsName, builder =>
                {
                    builder.WithOrigins(origins)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });

            });
        }

        static public void SetAnyCors(this WebApplicationBuilder builder, string corsName)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsName, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }
}
