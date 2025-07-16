using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Blog;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Category
{
    public record AddCategoryDTO : BlogAddDTO
    {
        public Guid? ParentCategoryId { get; init; }
        public string Name { get; init; } = null!;
        public string Slug { get; init; } = null!;
    }
}
