using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Extensions;
using TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink;

namespace TahaMucasiroglu.Application.Validation.Concrete.Entity.SocialLink
{
    public class UpdateSocialLinkListDTOValidation : AbstractValidator<IEnumerable<UpdateSocialLinkDTO>>
    {
        public UpdateSocialLinkListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateSocialLinkDTOValidation());
        }
    }
    public class UpdateSocialLinkDTOValidation : UpdateValidation<UpdateSocialLinkDTO>
    {
        public UpdateSocialLinkDTOValidation() : base()
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
