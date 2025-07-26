using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPost;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.BlogPost
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
