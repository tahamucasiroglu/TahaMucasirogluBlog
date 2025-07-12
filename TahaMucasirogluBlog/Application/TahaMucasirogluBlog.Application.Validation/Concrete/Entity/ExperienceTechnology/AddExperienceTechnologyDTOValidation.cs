using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.ExperienceTechnology
{
    public class AddExperienceTechnologyListDTOValidation : AbstractValidator<IEnumerable<AddExperienceTechnologyDTO>>
    {
        public AddExperienceTechnologyListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddExperienceTechnologyDTOValidation());
        }
    }
    public class AddExperienceTechnologyDTOValidation : AddValidation<AddExperienceTechnologyDTO>
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
