using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
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
