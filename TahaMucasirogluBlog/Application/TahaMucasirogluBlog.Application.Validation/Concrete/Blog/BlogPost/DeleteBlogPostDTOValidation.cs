using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPost;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.BlogPost
{
    public class DeleteBlogPostListDTOValidation : AbstractValidator<IEnumerable<DeleteBlogPostDTO>>
    {
        public DeleteBlogPostListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteBlogPostDTOValidation());
        }
    }
    public class DeleteBlogPostDTOValidation : BlogDeleteValidation<DeleteBlogPostDTO>
    {
        public DeleteBlogPostDTOValidation() : base()
        {
            
        }
    }
}
