using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Abstract.Blog;

namespace TahaMucasirogluBlog.Domain.DTOs.Base.Blog
{
    public record BlogRequestDTO : RequestDTO, IBlogRequestDTO
    {
    }
}
