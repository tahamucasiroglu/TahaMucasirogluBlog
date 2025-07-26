using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
{
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
            CreateMap<AddSkillDTO, Skill>().DefaultAddMapConfig();
            CreateMap<UpdateSkillDTO, Skill>().DefaultUpdateMapConfig();
            CreateMap<DeleteSkillDTO, Skill>().DefaultDeleteMapConfig();
            CreateMap<Skill, GetSkillDTO>();
        }
    }
}
