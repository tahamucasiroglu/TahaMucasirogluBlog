using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Main.SocialLink;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.SocialLink
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
