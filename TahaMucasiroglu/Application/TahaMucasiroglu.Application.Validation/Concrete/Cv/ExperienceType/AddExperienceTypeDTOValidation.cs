using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceType
{
    public class AddExperienceTypeListDTOValidation : AbstractValidator<IEnumerable<AddExperienceTypeDTO>>
    {
        public AddExperienceTypeListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddExperienceTypeDTOValidation());
        }
    }
    public class AddExperienceTypeDTOValidation : CvAddValidation<AddExperienceTypeDTO>
    {
        public AddExperienceTypeDTOValidation() : base()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} boş olamaz.")       // Required (not null or empty)
            .Length(2, 100)
            .WithMessage("{PropertyName} 2 ile 100 karakter arasında olmalı."); // Min 2, max 100 chars
        }
    }
}
