using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.ExperienceTechnology
{
    public class UpdateExperienceTechnologyListDTOValidation : AbstractValidator<IEnumerable<UpdateExperienceTechnologyDTO>>
    {
        public UpdateExperienceTechnologyListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateExperienceTechnologyDTOValidation());
        }
    }
    public class UpdateExperienceTechnologyDTOValidation : UpdateValidation<UpdateExperienceTechnologyDTO>
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
