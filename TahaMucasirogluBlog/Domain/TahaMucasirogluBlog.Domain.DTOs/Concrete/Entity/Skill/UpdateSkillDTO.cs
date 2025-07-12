using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill
{ 
    public record UpdateSkillDTO : UpdateDTO
    {
        public string Name { get; init; } = default!;
    }
}
