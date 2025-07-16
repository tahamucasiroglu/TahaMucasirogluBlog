using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv
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
