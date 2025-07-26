using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience
{
    public record AddExperienceDTO : CvAddDTO
    {
        public Guid ExperienceTypeId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Provider { get; init; } = string.Empty;
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Description { get; init; } = string.Empty;
        public string? Reference { get; init; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }
    }
}
