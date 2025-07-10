using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
