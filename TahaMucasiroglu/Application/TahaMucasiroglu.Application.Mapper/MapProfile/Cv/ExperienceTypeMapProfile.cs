using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
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
