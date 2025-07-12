using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class SubSkill : Entity
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; } = default!; // ".NET", "Teamwork" vb.
        public Skill Skill { get; set; } = default!;
        public ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = new HashSet<ExperienceTechnology>();

    }
}
