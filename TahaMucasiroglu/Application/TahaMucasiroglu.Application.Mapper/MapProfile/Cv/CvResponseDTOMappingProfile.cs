using AutoMapper;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
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
