using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Application.Validation.Concrete.Blog.BlogPost;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPost;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostCategory;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.BlogPostCategory
{
    public class AddBlogPostCategoryListDTOValidation : AbstractValidator<IEnumerable<AddBlogPostCategoryDTO>>
    {
        public AddBlogPostCategoryListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddBlogPostCategoryDTOValidation());
        }
    }
    public class AddBlogPostCategoryDTOValidation : BlogAddValidation<AddBlogPostCategoryDTO>
    {
        public AddBlogPostCategoryDTOValidation() : base()
        {
            RuleFor(x => x.PostId)
           .NotEmpty()
           .WithMessage("PostId zorunludur ve geçerli bir GUID olmalıdır.");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("CategoryId zorunludur ve geçerli bir GUID olmalıdır.");

            When(x => x.PostId != Guid.Empty, () =>
            {
                RuleFor(x => x.CategoryId)
                    .Must((model, categoryId) => categoryId != model.PostId)
                    .WithMessage("CategoryId, PostId ile aynı olamaz.");
            });
        }
    }
}
