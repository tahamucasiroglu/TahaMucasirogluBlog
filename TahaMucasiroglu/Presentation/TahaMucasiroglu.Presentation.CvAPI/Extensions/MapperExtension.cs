using TahaMucasiroglu.Application.Mapper.MapProfile.Cv;

namespace TahaMucasiroglu.Presentation.CvAPI.Extensions
{
    static public class MapperExtension
    {
        public static void AddMapperMapProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CvResponseDTOMappingProfile));
            services.AddAutoMapper(typeof(ExperienceMapProfile));
            services.AddAutoMapper(typeof(ExperienceTechnologyMapProfile));
            services.AddAutoMapper(typeof(ExperienceTypeMapProfile));
            services.AddAutoMapper(typeof(InfoMapProfile));
            services.AddAutoMapper(typeof(SkillMapProfile));
            services.AddAutoMapper(typeof(SubSkillMapProfile));
        }
    }
}
