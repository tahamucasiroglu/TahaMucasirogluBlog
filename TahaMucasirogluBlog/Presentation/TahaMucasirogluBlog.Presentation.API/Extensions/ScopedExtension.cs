using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.BlogRepository.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete;
using TahaMucasirogluBlog.Service.Cv.Abstract;
using TahaMucasirogluBlog.Service.Cv.Concrete;
using TahaMucasirogluBlog.Service.Database.Abstract.Main;
using TahaMucasirogluBlog.Service.Database.Concrete.Main;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {




            builder.Services.AddScoped<ICvService, CvService>();



        }
    }
}
