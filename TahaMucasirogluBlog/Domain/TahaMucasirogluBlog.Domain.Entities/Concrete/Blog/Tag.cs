using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete.Blog
{
    public class Tag : BlogEntity
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public ICollection<BlogPostTag> PostTags { get; set; } = new HashSet<BlogPostTag>();

    }
}
