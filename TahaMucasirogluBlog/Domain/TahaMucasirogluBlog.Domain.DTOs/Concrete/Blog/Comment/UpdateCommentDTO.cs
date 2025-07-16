using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;
using TahaMucasirogluBlog.Domain.DTOs.Base.Blog;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Comment
{
    public record UpdateCommentDTO : BlogUpdateDTO
    {
        public Guid PostId { get; init; }
        public Guid? ParentCommentId { get; init; }
        public string Content { get; init; } = null!;
        public bool IsApproved { get; init; }
    }
}
