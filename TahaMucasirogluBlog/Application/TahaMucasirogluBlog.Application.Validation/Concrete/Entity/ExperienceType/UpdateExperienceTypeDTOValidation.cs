using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.ExperienceType
{
    public class UpdateExperienceTypeListDTOValidation : AbstractValidator<IEnumerable<UpdateExperienceTypeDTO>>
    {
        public UpdateExperienceTypeListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateExperienceTypeDTOValidation());
        }
    }
    public class UpdateExperienceTypeDTOValidation : UpdateValidation<UpdateExperienceTypeDTO>
    {
        public UpdateExperienceTypeDTOValidation() : base()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz.")       // Required (not null or empty)
            .Length(2, 100)
            .WithMessage("{PropertyName} 2 ile 100 karakter arasında olmalı."); // Min 2, max 100 chars
        }
    }
}
