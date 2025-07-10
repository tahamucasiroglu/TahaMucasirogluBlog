using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostTag;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPostTag
{
    public class DeleteBlogPostTagValidation : DeleteValidation<DeleteBlogPostTagDTO>
    {
        public DeleteBlogPostTagValidation() : base()
        {
            
        }
    }
}
