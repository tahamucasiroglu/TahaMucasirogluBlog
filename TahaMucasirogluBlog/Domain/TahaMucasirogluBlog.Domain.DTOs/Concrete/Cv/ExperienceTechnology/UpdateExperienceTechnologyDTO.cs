using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Cv;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology
{
    public record UpdateExperienceTechnologyDTO : CvUpdateDTO
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
    }
}
