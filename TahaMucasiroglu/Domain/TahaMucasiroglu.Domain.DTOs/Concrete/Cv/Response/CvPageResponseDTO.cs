using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Response
{
    public record CvPageResponseDTO : ResponseDTO
    {
        public GetInfoDTO Info { get; set; } = default!;
        public List<GetSocialLinkDTO> SocialLinks { get; set; } = default!;
        public List<GetSkillWithSubSkillsDTO> Skills { get; set; } = new();
        public List<GetExperienceWithTechnologyAndTypeDTO> Experiences { get; set; } = new();
    }
}
