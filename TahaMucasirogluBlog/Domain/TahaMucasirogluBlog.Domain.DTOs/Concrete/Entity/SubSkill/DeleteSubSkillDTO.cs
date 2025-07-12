using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill
{
    public record DeleteSubSkillDTO : DeleteDTO
    {
        public Guid SkillId { get; init; }
        public string Name { get; init; } = default!; // ".NET", "Teamwork" vb.
    }
}
