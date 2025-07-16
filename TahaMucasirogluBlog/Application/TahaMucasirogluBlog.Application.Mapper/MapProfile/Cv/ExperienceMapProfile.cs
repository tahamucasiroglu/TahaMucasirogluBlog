using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv
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
