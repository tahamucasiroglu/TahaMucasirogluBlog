using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
namespace TahaMucasiroglu.Presentation.API.Extensions
{
    static public class JsonExtension
    {
        static public IMvcBuilder AddNewtonsoftJson(this WebApplicationBuilder builder)
        {
            return builder.Services
            .AddControllers()
            .AddNewtonsoftJson(opts =>
            {
                opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }
    }
}
