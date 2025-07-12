using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType
{
    public record UpdateExperienceTypeDTO : UpdateDTO
    {
        public string Name { get; init; } = string.Empty;
    }
}
