using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class Tag : Entity
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public ICollection<BlogPostTag> PostTags { get; set; } = new HashSet<BlogPostTag>();

    }
}
