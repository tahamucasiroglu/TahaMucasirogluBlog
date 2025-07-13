using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasirogluBlog.Domain.Models.Entity
{
    public class GetSubSkillModel : Model
    {
        public Guid SkillId { get; set; }
        public string Name { get; set; } = default!; // ".NET", "Teamwork" vb.
    }
}
