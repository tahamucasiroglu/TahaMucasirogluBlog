using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology
{
    public record AddExperienceTechnologyDTO : AddDTO
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
    }
}
