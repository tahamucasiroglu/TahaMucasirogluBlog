using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostCategory;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.BlogPostCategory
{
    public class DeleteBlogPostCategoryListDTOValidation : AbstractValidator<IEnumerable<DeleteBlogPostCategoryDTO>>
    {
        public DeleteBlogPostCategoryListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteBlogPostCategoryDTOValidation());
        }
    }
    public class DeleteBlogPostCategoryDTOValidation : BlogDeleteValidation<DeleteBlogPostCategoryDTO>
    {
        public DeleteBlogPostCategoryDTOValidation() : base()
        {
            
        }
    }
}
