
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;

using TahaMucasirogluBlog.Service.Database.Abstract.Main;
using TahaMucasirogluBlog.Service.Database.Concrete.Main;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {




            builder.Services.AddScoped<ICvService, CvService>();



        }
    }
}
