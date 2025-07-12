using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class Skill : Entity
    {
        public string Name { get; set; } = default!; // "Backend", "Soft Skill" gibi
        public ICollection<SubSkill> SubSkills { get; set; } = new List<SubSkill>();
    }
}
