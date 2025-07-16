using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
