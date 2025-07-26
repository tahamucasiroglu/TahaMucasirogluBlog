using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType
{
    public record UpdateExperienceTypeDTO : CvUpdateDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
