using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.SubSkill
{
    public class UpdateSubSkillListDTOValidation : AbstractValidator<IEnumerable<UpdateSubSkillDTO>>
    {
        public UpdateSubSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateSubSkillDTOValidation());
        }
    }
    public class UpdateSubSkillDTOValidation : CvUpdateValidation<UpdateSubSkillDTO>
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
