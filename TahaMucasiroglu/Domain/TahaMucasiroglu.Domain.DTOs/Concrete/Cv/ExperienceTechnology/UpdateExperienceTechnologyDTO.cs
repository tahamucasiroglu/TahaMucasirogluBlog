using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology
{
    public record UpdateExperienceTechnologyDTO : CvUpdateDTO
    {
        public Guid ExperienceId { get; set; }
        public Guid SubSkillId { get; set; }
    }
}
