﻿using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Skill
{
    public class UpdateSkillListDTOValidation : AbstractValidator<IEnumerable<UpdateSkillDTO>>
    {
        public UpdateSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateSkillDTOValidation());
        }
    }
    public class UpdateSkillDTOValidation : CvUpdateValidation<UpdateSkillDTO>
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
