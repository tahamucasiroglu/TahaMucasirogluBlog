using System.Xml.Linq;
using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete.Blog
{
    public class BlogPost : BlogEntity
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public long ViewCount { get; set; }

        public User User { get; set; } = default!;


        public ICollection<BlogPostCategory> PostCategories { get; set; } = new HashSet<BlogPostCategory>();
        public ICollection<BlogPostTag> PostTags { get; set; } = new HashSet<BlogPostTag>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
