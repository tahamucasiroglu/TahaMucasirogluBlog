using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Blog;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostCategory
{
    public record AddBlogPostCategoryDTO : BlogAddDTO
    {
        public Guid PostId { get; init; }
        public Guid CategoryId { get; init; }
    }
}
