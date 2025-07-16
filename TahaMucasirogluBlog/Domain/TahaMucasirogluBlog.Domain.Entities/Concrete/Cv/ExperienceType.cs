using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete.Cv
{
    public class ExperienceType : CvEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Experience> Experiences { get; set; } = new HashSet<Experience>();
    }
}
