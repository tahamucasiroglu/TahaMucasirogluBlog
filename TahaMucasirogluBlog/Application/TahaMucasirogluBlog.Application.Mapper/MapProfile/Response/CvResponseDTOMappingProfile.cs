using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Response
{
    public class CvResponseDTOMappingProfile : Profile
    {
        public CvResponseDTOMappingProfile()
        {
            // Experience => GetExperienceWithTechnologyAndTypeDTO
            CreateMap<Experience, GetExperienceWithTechnologyAndTypeDTO>()
                .ForMember(dest => dest.ExperienceType, opt => opt.MapFrom(src => src.ExperienceType))
                .ForMember(dest => dest.SubSkills, opt => opt.MapFrom(src => src.ExperienceTechnologies));//burada dönüşüm hatası olacak

            // Skill => GetSkillWithSubSkillsDTO
            CreateMap<Skill, GetSkillWithSubSkillsDTO>()
                .ForMember(dest => dest.SubSkills, opt => opt.MapFrom(src => src.SubSkills));
        }
    }
}
