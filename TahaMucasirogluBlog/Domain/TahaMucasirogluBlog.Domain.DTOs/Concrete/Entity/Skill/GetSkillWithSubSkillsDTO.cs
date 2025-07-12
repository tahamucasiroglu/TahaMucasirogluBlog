using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill
{
    public record GetSkillWithSubSkillsDTO : GetDTO
    {
        public string Name { get; set; } = default!;
        public List<GetSubSkillDTO> SubSkills { get; set; } = new();
    }
}
