using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Application.Validation.Concrete.Blog.BlogPostCategory;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostTag;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.BlogPostTag
{
    public class AddBlogPostTagListDTOValidation : AbstractValidator<IEnumerable<AddBlogPostTagDTO>>
    {
        public AddBlogPostTagListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddBlogPostTagDTOValidation());
        }
    }
    public class AddBlogPostTagDTOValidation : BlogAddValidation<AddBlogPostTagDTO>
    {
        public AddBlogPostTagDTOValidation() : base()
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
