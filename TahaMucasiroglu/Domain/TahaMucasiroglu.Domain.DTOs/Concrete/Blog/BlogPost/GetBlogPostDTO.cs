﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Blog;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPost
{
    public record GetBlogPostDTO : BlogGetDTO
    {
        public Guid AuthorId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
        public long ViewCount { get; init; }
    }
}
