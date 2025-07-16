using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete.Cv
{
    public class ExperienceTechnology : CvEntity
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
        public Experience Experience { get; set; } = default!;
        public SubSkill SubSkill { get; set; } = default!;
    }
}
