using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType
{
    public record GetExperienceTypeDTO : GetDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
