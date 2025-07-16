using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Blog;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostTag
{
    public record GetBlogPostTagDTO : BlogGetDTO
    {
        public Guid PostId { get; init; }
        public Guid TagId { get; init; }
    }
}
