using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology
{
    public record GetExperienceTechnologyDTO : CvGetDTO
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
    }
}
