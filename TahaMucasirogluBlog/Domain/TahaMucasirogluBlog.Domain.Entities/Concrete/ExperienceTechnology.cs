using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class ExperienceTechnology : Entity
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
        public Experience Experience { get; set; } = default!;
        public SubSkill SubSkill { get; set; } = default!;
    }
}
