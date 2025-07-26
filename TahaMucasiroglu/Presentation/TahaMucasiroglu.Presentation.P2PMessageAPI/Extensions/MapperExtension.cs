using TahaMucasiroglu.Application.Mapper.MapProfile.Statistic;

namespace TahaMucasiroglu.Presentation.P2PMessageAPI.Extensions
{
    static public class MapperExtension
    {
        public static void AddMapperMapProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(P2PMessageStatisticMapProfile));
        }
    }
}
