using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Request
{
    public record HealthCheckRequestDTO : RequestDTO
    {
        public int Num1 { get; init; }
        public int Num2 { get; init; }
    }
}
