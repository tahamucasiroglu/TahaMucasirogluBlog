using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Blog
{
    public class BlogPostTag : BlogEntity
    {
        public Guid PostId { get; set; }
        public Guid TagId { get; set; }

        public BlogPost BlogPost { get; set; } = default!;
        public Tag Tag { get; set; } = default!;
    }
}
