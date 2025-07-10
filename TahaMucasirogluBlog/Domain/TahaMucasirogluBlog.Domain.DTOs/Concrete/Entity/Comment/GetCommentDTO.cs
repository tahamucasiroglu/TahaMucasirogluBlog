using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Comment
{
    public record GetCommentDTO : GetDTO
    {
        public Guid PostId { get; init; }
        public Guid? ParentCommentId { get; init; }
        public string Content { get; init; } = null!;
        public bool IsApproved { get; init; }
    }
}
