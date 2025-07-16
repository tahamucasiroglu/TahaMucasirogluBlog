using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Cv;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType
{
    public record GetExperienceTypeDTO : CvGetDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
