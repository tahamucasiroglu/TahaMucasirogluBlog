using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Blog;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostTag
{
    public record UpdateBlogPostTagDTO : BlogUpdateDTO
    {
        public Guid PostId { get; init; }
        public Guid TagId { get; init; }
    }
}
