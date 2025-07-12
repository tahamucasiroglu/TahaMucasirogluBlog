using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience
{
    public record GetExperienceWithTechnologyAndTypeDTO : GetDTO
    {
        public string Title { get; init; } = string.Empty;
        public string Provider { get; init; } = string.Empty;
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public string Description { get; init; } = string.Empty;
        public string? Reference { get; init; }

        public GetExperienceTypeDTO ExperienceType { get; init; } = default!;
        public List<GetExperienceTechnologyDTO> ExperienceTechnologies { get; init; } = new();
    }
}
