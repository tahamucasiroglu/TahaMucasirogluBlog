using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink;

namespace TahaMucasiroglu.Application.Validation.Concrete.Entity.SocialLink
{
    public class DeleteSocialLinkListDTOValidation : AbstractValidator<IEnumerable<DeleteSocialLinkDTO>>
    {
        public DeleteSocialLinkListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteSocialLinkDTOValidation());
        }
    }
    public class DeleteSocialLinkDTOValidation : DeleteValidation<DeleteSocialLinkDTO>
    {
        public DeleteSocialLinkDTOValidation() : base()
        {

        }
    }
}
