using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
{
    public class ExperienceTechnologyMapProfile : Profile
    {
        public ExperienceTechnologyMapProfile()
        {
            CreateMap<AddExperienceTechnologyDTO, ExperienceTechnology>().DefaultAddMapConfig();
            CreateMap<UpdateExperienceTechnologyDTO, ExperienceTechnology>().DefaultUpdateMapConfig();
            CreateMap<DeleteExperienceTechnologyDTO, ExperienceTechnology>().DefaultDeleteMapConfig();
            CreateMap<ExperienceTechnology, GetExperienceTechnologyDTO>();
        }
    }
}
