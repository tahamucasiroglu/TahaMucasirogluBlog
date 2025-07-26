using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Cv
{
    public class Skill : CvEntity
    {
        public string Name { get; set; } = default!; // "Backend", "Soft Skill" gibi
        public ICollection<SubSkill> SubSkills { get; set; } = new List<SubSkill>();
    }
}
