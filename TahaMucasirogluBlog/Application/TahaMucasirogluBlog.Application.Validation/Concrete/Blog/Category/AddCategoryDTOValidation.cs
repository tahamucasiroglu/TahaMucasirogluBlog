using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostTag;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Category;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.Category
{
    public class AddCategoryListDTOValidation : AbstractValidator<IEnumerable<AddCategoryDTO>>
    {
        public AddCategoryListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddCategoryDTOValidation());
        }
    }
    public class AddCategoryDTOValidation : BlogAddValidation<AddCategoryDTO>
    {
        public AddCategoryDTOValidation() : base()
        {
            // ParentCategoryId: nullable olabilir ama boş GUID olmamalı
            RuleFor(x => x.ParentCategoryId)
                .Must(id => id == null || id != Guid.Empty)
                .WithMessage("ParentCategoryId, boş GUID olamaz.");

            // Name: boş olmamalı, trim sonrası minimum/maximum sınırı
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name zorunludur.")
                .Length(2, 100)
                .WithMessage("Category name 2–100 karakter arası olmalıdır.");

            // Slug: boş olmamalı, regex kontrolüyle güvenli URL formatını sağlamalı
            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug zorunludur.")
                .Matches("^[a-z0-9]+(-[a-z0-9]+)*$")
                .WithMessage("Slug yalnızca küçük harf, rakam ve '-' içermelidir.");
        }
    }
}
