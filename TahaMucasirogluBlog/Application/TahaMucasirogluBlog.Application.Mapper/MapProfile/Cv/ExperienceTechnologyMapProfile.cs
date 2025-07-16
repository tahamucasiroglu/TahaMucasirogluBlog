using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv
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
