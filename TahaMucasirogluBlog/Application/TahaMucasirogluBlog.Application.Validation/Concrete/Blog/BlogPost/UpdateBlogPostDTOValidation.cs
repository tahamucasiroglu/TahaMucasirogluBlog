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

    public class UpdateBlogPostListDTOValidation : AbstractValidator<IEnumerable<UpdateBlogPostDTO>>
    {
        public UpdateBlogPostListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateBlogPostDTOValidation());
        }
    }
    public class UpdateBlogPostDTOValidation : BlogUpdateValidation<UpdateBlogPostDTO>
    {
        public UpdateBlogPostDTOValidation() : base()
        {
            // Yazar ID'si boş (default Guid) olmamalı
            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .WithMessage("AuthorId zorunludur.");

            // Başlık boş olmamalı, minimum/maximum uzunluk olabilir
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title boş olamaz.")
                .Length(5, 200).WithMessage("Title 5–200 karakter olmalı.");

            // Slug boş olmamalı, düzenli ifade ile kontrol (sadece a–z, 0–9 ve -)
            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug boş olamaz.")
                .Matches("^[a-z0-9]+(-[a-z0-9]+)*$")
                .WithMessage("Slug yalnızca küçük harf, rakam ve - içermeli.");

            // İçerik boş olmamalı, minimum uzunluk olabilir
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content boş olamaz.")
                .MinimumLength(20).WithMessage("Content en az 20 karakter olmalı.");

            // ViewCount negatif olamaz
            RuleFor(x => x.ViewCount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ViewCount negatif olamaz.");
        }
    }
}
