using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
{
    public class SubSkillMapProfile : Profile
    {
        public SubSkillMapProfile()
        {
            CreateMap<AddSubSkillDTO, SubSkill>().DefaultAddMapConfig();
            CreateMap<UpdateSubSkillDTO, SubSkill>().DefaultUpdateMapConfig();
            CreateMap<DeleteSubSkillDTO, SubSkill>().DefaultDeleteMapConfig();
            CreateMap<SubSkill, GetSubSkillDTO>();
        }
    }
}
