using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill
{
    public record GetSkillWithSubSkillsDTO : CvGetDTO
    {
        public string Name { get; set; } = default!;
        public List<GetSubSkillDTO> SubSkills { get; set; } = new();
    }
}
