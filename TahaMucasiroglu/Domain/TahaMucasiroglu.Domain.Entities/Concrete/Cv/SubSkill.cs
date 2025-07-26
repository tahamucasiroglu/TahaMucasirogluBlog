using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Cv
{
    public class SubSkill : CvEntity
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; } = default!; // ".NET", "Teamwork" vb.
        public string? Explanation { get; set; }
        public Skill Skill { get; set; } = default!;
        public ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = new HashSet<ExperienceTechnology>();

    }
}
