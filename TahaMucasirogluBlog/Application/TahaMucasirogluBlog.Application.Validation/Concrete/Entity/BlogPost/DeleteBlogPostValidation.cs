using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPost;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPost
{
    public class DeleteBlogPostValidation : DeleteValidation<DeleteBlogPostDTO>
    {
        public DeleteBlogPostValidation() : base()
        {
            
        }
    }
}
