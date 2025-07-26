using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience
{
    public record GetExperienceWithTechnologyAndTypeDTO : CvGetDTO
    {
        public string Title { get; init; } = string.Empty;
        public string Provider { get; init; } = string.Empty;
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Description { get; init; } = string.Empty;
        public string? Reference { get; init; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }

        public GetExperienceTypeDTO ExperienceType { get; init; } = default!;
        public List<GetSubSkillDTO> SubSkills { get; init; } = new();
    }
}
