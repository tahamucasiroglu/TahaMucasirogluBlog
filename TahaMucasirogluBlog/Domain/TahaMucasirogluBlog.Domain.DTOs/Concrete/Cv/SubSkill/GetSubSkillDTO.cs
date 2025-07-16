using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Cv;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill
{
    public record GetSubSkillDTO : CvGetDTO
    {
        public Guid SkillId { get; init; }
        public string Name { get; init; } = default!; // ".NET", "Teamwork" vb.
        public string? Explanation { get; set; }
    }
}
