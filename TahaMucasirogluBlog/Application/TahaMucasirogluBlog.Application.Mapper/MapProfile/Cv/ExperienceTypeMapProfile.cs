using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv
{
    public class ExperienceTypeMapProfile : Profile
    {
        public ExperienceTypeMapProfile()
        {
            CreateMap<AddExperienceTypeDTO, ExperienceType>().DefaultAddMapConfig();
            CreateMap<UpdateExperienceTypeDTO, ExperienceType>().DefaultUpdateMapConfig();
            CreateMap<DeleteExperienceTypeDTO, ExperienceType>().DefaultDeleteMapConfig();
            CreateMap<ExperienceType, GetExperienceTypeDTO>();
        }
    }
}
