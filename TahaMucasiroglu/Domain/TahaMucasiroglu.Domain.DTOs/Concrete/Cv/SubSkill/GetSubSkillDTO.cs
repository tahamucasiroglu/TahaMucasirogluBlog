using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill
{
    public record GetSubSkillDTO : CvGetDTO
    {
        public Guid SkillId { get; init; }
        public string Name { get; init; } = default!; // ".NET", "Teamwork" vb.
        public string? Explanation { get; set; }
    }
}
