using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract.Blog;

namespace TahaMucasiroglu.Domain.DTOs.Base.Blog
{
    public record BlogIdDTO : IdDTO, IBlogIdDTO
    {
    }
}
