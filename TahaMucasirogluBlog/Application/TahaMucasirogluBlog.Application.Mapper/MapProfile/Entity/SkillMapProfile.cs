using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
