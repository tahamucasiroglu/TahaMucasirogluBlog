using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class Comment : Entity
    {
        public Guid PostId { get; set; }
        public Guid? ParentCommentId { get; set; }
        public string Content { get; set; } = null!;
        public bool IsApproved { get; set; }

        public BlogPost BlogPost { get; set; } = default!;
        public Comment? ParentComment { get; set; } = default!;

        public ICollection<Comment>? Replies { get; set; } = new HashSet<Comment>();

    }
}
