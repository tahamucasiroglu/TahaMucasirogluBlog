using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostTag;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.BlogPostTag
{
    public class UpdateBlogPostTagListDTOValidation : AbstractValidator<IEnumerable<UpdateBlogPostTagDTO>>
    {
        public UpdateBlogPostTagListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateBlogPostTagDTOValidation());
        }
    }
    public class UpdateBlogPostTagDTOValidation : BlogUpdateValidation<UpdateBlogPostTagDTO>
    {
        public UpdateBlogPostTagDTOValidation() : base()
        {
            // PostId boş olamaz
            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("PostId zorunludur ve geçerli bir GUID olmalıdır.");

            // TagId boş olamaz
            RuleFor(x => x.TagId)
                .NotEmpty()
                .WithMessage("TagId zorunludur ve geçerli bir GUID olmalıdır.");

            // PostId doluysa, TagId PostId ile aynı olamaz
            When(x => x.PostId != Guid.Empty, () =>
            {
                RuleFor(x => x.TagId)
                    .Must((model, tagId) => tagId != model.PostId)
                    .WithMessage("TagId, PostId ile aynı olamaz.");
            });
        }
    }
}
