using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Models.Base;

namespace TahaMucasiroglu.Domain.Models.Concrete.Cv
{
    public class GetSubSkillModel : CvModel
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; } = default!; // ".NET", "Teamwork" vb.
        public string? Explanation { get; set; }
    }
}
