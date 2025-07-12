using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Response
{
    public class CvResponseDTOMappingProfile : Profile
    {
        public CvResponseDTOMappingProfile()
        {
            // Experience => GetExperienceWithTechnologyAndTypeDTO
            CreateMap<Experience, GetExperienceWithTechnologyAndTypeDTO>()
                .ForMember(dest => dest.ExperienceType, opt => opt.MapFrom(src => src.ExperienceType))
                .ForMember(dest => dest.ExperienceTechnologies, opt => opt.MapFrom(src => src.ExperienceTechnologies));

            // Skill => GetSkillWithSubSkillsDTO
            CreateMap<Skill, GetSkillWithSubSkillsDTO>()
                .ForMember(dest => dest.SubSkills, opt => opt.MapFrom(src => src.SubSkills));
        }
    }
}
