using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.ExperienceTechnology
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
