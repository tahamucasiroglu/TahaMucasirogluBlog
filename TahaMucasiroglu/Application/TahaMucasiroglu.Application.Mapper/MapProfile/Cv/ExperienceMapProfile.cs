using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
{
    public class ExperienceMapProfile : Profile
    {
        public ExperienceMapProfile()
        {
            CreateMap<AddExperienceDTO, Experience>().DefaultAddMapConfig();
            CreateMap<UpdateExperienceDTO, Experience>().DefaultUpdateMapConfig();
            CreateMap<DeleteExperienceDTO, Experience>().DefaultDeleteMapConfig();
            CreateMap<Experience, GetExperienceDTO>();
        }
    }
}
