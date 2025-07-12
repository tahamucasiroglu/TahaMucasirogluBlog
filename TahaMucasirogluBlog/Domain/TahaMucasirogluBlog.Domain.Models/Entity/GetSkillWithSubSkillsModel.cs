using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasirogluBlog.Domain.Models.Entity
{
    public class GetSkillWithSubSkillsModel
    {
        public string Name { get; set; } = default!;
        public List<GetSubSkillModel> SubSkills { get; set; } = new();
    }
}
