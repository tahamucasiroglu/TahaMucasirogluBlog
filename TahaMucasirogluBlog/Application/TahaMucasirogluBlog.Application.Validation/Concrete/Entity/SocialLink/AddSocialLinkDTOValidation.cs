using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Extensions;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Main.SocialLink;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.SocialLink
{
    public class AddSocialLinkListDTOValidation : AbstractValidator<IEnumerable<AddSocialLinkDTO>>
    {
        public AddSocialLinkListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddSocialLinkDTOValidation());
        }
    }
    public class AddSocialLinkDTOValidation : AddValidation<AddSocialLinkDTO>
    {
        public AddSocialLinkDTOValidation() : base()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name boş olamaz")
           .MaximumLength(100).WithMessage("Name en fazla 100 karakter olabilir");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Url boş olamaz")
                .MaximumLength(500).WithMessage("Url en fazla 500 karakter olabilir")
                .Url() // Örnek olarak bizim custom URL validator'ı kullanıyoruz
                .WithMessage("Geçerli bir URL olmalı");

            RuleFor(x => x.IconClass)
                .MaximumLength(100).WithMessage("IconClass en fazla 100 karakter olabilir")
                .When(x => x.IconClass != null);

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("DisplayOrder sıfırdan küçük olamaz");
        }
    }
}
