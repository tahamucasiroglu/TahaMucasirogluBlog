
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Concrete;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract;
using TahaMucasiroglu.Service.StatisticDatabase.Concrete;

namespace TahaMucasiroglu.Presentation.StatisticAPI.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IP2PMessageStatisticDatabaseService, P2PMessageStatisticDatabaseService>();
            builder.Services.AddScoped<ICvStatisticDatabaseService, CvStatisticDatabaseService>();



            builder.Services.AddScoped<IP2PMessageStatisticRepository, P2PMessageStatisticRepository>();
            builder.Services.AddScoped<ICvStatisticRepository, CvStatisticRepository>();


        }
    }
}
