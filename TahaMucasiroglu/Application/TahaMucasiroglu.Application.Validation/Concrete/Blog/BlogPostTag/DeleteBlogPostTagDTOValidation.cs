using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostTag;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.BlogPostTag
{
    public class DeleteBlogPostTagListDTOValidation : AbstractValidator<IEnumerable<DeleteBlogPostTagDTO>>
    {
        public DeleteBlogPostTagListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteBlogPostTagDTOValidation());
        }
    }
    public class DeleteBlogPostTagDTOValidation : BlogDeleteValidation<DeleteBlogPostTagDTO>
    {
        public DeleteBlogPostTagDTOValidation() : base()
        {
            
        }
    }
}
