using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Concrete;
using TahaMucasiroglu.Service.P2PMessageDatabase.Abstract;
using TahaMucasiroglu.Service.P2PMessageDatabase.Concrete;

namespace TahaMucasiroglu.Presentation.P2PMessageAPI.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IP2PMessageStatisticDatabaseService, P2PMessageStatisticDatabaseService>();

            builder.Services.AddScoped<IP2PMessageStatisticRepository, P2PMessageStatisticRepository>();


        }
    }
}
