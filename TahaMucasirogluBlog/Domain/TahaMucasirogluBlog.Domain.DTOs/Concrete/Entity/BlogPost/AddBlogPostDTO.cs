using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPost
{
    public record AddBlogPostDTO : AddDTO
    {
        public Guid AuthorId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
        public long ViewCount { get; init; }
    }
}
