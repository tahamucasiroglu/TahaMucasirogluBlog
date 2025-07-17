using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Extensions
{
    public static class CorsExtension
    {
        static public void SetCors(this WebApplicationBuilder builder, string corsName, params string[] origins)
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
