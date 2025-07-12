using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.SubSkill
{
    public class UpdateSubSkillListDTOValidation : AbstractValidator<IEnumerable<UpdateSubSkillDTO>>
    {
        public UpdateSubSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateSubSkillDTOValidation());
        }
    }
    public class UpdateSubSkillDTOValidation : UpdateValidation<UpdateSubSkillDTO>
    {
        public UpdateSubSkillDTOValidation() : base()
        {
            RuleFor(x => x.SkillId)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz."); // Guid.Empty kontrolü

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} boş olamaz.")
                .Length(2, 100)
                .WithMessage("{PropertyName} 2 ile 100 karakter arasında olmalı.");

        }
    }
}
