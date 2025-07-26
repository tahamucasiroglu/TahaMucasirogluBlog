using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace TahaMucasiroglu.Client.MVC.Extensions
{
    static public class JsonExtension
    {
        static public IMvcBuilder AddNewtonsoftJson(this WebApplicationBuilder builder)
        {
            return builder.Services
            .AddControllers()
            .AddNewtonsoftJson(opts =>
            {
                // Döngüsel referansları yoksay
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // Null değerleri at
                opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }
    }
}
