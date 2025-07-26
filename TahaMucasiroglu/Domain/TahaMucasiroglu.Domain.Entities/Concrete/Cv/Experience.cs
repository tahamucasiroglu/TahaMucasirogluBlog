using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Cv
{
    public class Experience : CvEntity
    {
        public Guid ExperienceTypeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Reference { get; set; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }

        public ExperienceType ExperienceType { get; set; } = default!;
        public ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = new HashSet<ExperienceTechnology>();
    }
}
