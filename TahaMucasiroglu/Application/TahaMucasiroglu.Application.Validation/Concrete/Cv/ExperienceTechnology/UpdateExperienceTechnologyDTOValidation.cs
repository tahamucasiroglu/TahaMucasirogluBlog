using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceTechnology
{
    public class UpdateExperienceTechnologyListDTOValidation : AbstractValidator<IEnumerable<UpdateExperienceTechnologyDTO>>
    {
        public UpdateExperienceTechnologyListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateExperienceTechnologyDTOValidation());
        }
    }
    public class UpdateExperienceTechnologyDTOValidation : CvUpdateValidation<UpdateExperienceTechnologyDTO>
    {
        public UpdateExperienceTechnologyDTOValidation() : base()
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
