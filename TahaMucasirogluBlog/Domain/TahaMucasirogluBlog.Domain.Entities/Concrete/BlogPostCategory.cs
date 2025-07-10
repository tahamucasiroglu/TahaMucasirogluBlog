using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class BlogPostCategory : Entity
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }

        public BlogPost BlogPost { get; set; } = default!;
        public Category Category { get; set; } = default!;
    }
}
