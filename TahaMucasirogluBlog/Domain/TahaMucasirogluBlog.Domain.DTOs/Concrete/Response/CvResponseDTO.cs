using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SocialLink;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Response
{
    public record CvResponseDTO : ResponseDTO
    {
        public GetInfoDTO Info { get; set; } = default!;
        public List<GetSocialLinkDTO> SocialLinks { get; set; } = default!;
        public List<GetSkillWithSubSkillsDTO> Skills { get; set; } = new();
        public List<GetExperienceWithTechnologyAndTypeDTO> Experiences { get; set; } = new();
    }
}
