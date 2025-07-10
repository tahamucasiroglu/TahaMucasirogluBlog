using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class Category : Entity
    {
        public Guid? ParentCategoryId {  get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public Category? ParrentCategory { get; set; } = default!;
        
        public ICollection<BlogPostCategory> PostCategories { get; set; } = new HashSet<BlogPostCategory>();
        
    }
}
