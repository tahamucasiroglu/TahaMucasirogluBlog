using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Cv;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology
{
    public record GetExperienceTechnologyDTO : CvGetDTO
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
    }
}
