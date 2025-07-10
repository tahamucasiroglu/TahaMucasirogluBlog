using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostCategory;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPostCategory
{
    public class DeleteBlogPostCategoryDTOValidation : DeleteValidation<DeleteBlogPostCategoryDTO>
    {
        public DeleteBlogPostCategoryDTOValidation() : base()
        {
            
        }
    }
}
