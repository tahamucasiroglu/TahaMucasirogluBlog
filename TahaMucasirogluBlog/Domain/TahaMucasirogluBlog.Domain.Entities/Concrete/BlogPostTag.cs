using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class BlogPostTag : Entity
    {
        public Guid PostId { get; set; }
        public Guid TagId { get; set; }

        public BlogPost BlogPost { get; set; } = default!;
        public Tag Tag { get; set; } = default!;
    }
}
