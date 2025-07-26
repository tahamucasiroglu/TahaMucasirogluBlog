using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Blog;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Comment
{
    public record GetCommentDTO : BlogGetDTO
    {
        public Guid PostId { get; init; }
        public Guid? ParentCommentId { get; init; }
        public string Content { get; init; } = null!;
        public bool IsApproved { get; init; }
    }
}
