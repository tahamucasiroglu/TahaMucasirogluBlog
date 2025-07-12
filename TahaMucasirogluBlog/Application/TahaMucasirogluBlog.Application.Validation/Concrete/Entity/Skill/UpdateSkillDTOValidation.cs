using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Skill
{
    public class UpdateSkillListDTOValidation : AbstractValidator<IEnumerable<UpdateSkillDTO>>
    {
        public UpdateSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateSkillDTOValidation());
        }
    }
    public class UpdateSkillDTOValidation : UpdateValidation<UpdateSkillDTO>
    {
        public UpdateSkillDTOValidation() : base()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz.")       // Required (not null or empty)
            .Length(2, 100)
            .WithMessage("{PropertyName} 2 ile 100 karakter arasında olmalı."); // Min 2, max 100 chars
        }
    }
}
