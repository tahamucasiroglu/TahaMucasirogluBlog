using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info
{
    public record UpdateInfoDTO : UpdateDTO
    {
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Location { get; init; } = string.Empty; // Konum
        public string CoverLetter { get; set; } = string.Empty;
    }
}
