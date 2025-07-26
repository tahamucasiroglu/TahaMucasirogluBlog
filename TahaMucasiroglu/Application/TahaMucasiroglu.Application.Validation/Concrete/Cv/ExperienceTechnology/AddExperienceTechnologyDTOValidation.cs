using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceTechnology
{
    public class AddExperienceTechnologyListDTOValidation : AbstractValidator<IEnumerable<AddExperienceTechnologyDTO>>
    {
        public AddExperienceTechnologyListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddExperienceTechnologyDTOValidation());
        }
    }
    public class AddExperienceTechnologyDTOValidation : CvAddValidation<AddExperienceTechnologyDTO>
    {
        public AddExperienceTechnologyDTOValidation() : base()
        {
            RuleFor(x => x.ExperienceId)
            .NotEmpty()
            .WithMessage("ExperienceId boş olamaz.");

            RuleFor(x => x.SubSkillId)
                .NotEmpty()
                .WithMessage("SubSkillId boş olamaz.");
        }
    }
}
