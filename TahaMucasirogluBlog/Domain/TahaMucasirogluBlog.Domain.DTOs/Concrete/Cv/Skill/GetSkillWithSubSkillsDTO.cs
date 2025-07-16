using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill
{
    public record GetSkillWithSubSkillsDTO : CvGetDTO
    {
        public string Name { get; set; } = default!;
        public List<GetSubSkillDTO> SubSkills { get; set; } = new();
    }
}
