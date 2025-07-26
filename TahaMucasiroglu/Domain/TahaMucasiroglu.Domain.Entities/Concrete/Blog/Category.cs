using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Blog
{
    public class Category : BlogEntity
    {
        public Guid? ParentCategoryId {  get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;

        public Category? ParrentCategory { get; set; } = default!;
        
        public ICollection<BlogPostCategory> PostCategories { get; set; } = new HashSet<BlogPostCategory>();
        public ICollection<Category>? SubCategories { get; set; } = new HashSet<Category>();
        
    }
}
