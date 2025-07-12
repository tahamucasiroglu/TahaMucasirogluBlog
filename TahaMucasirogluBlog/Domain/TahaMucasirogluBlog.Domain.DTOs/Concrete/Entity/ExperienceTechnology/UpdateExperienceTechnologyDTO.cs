using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology
{
    public record UpdateExperienceTechnologyDTO : UpdateDTO
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
    }
}
