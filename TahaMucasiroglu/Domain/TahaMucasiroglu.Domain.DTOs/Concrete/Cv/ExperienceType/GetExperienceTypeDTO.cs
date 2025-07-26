using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType
{
    public record GetExperienceTypeDTO : CvGetDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
