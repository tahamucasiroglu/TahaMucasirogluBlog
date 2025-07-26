using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Cv;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill
{
    public record AddSubSkillDTO : CvAddDTO
    {
        public Guid SkillId { get; init; }
        public string Name { get; init; } = default!; // ".NET", "Teamwork" vb.
        public string? Explanation { get; set; }
    }
}
