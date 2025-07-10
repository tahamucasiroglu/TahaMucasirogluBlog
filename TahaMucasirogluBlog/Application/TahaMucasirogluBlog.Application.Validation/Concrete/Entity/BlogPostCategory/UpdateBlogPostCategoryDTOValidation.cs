using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostCategory;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPostCategory
{
    public class UpdateBlogPostCategoryDTOValidation : UpdateValidation<UpdateBlogPostCategoryDTO>
    {
        public UpdateBlogPostCategoryDTOValidation() : base()
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
