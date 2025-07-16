using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv
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
