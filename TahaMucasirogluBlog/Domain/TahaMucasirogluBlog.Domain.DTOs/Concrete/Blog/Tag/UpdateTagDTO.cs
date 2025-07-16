using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Blog;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Tag
{
    public record UpdateTagDTO : BlogUpdateDTO
    {
        public string Name { get; init; } = null!;
        public string Slug { get; init; } = null!;
    }
}
