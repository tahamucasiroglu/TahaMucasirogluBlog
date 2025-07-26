using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceType
{
    public class DeleteExperienceTypeListDTOValidation : AbstractValidator<IEnumerable<DeleteExperienceTypeDTO>>
    {
        public DeleteExperienceTypeListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteExperienceTypeDTOValidation());
        }
    }
    public class DeleteExperienceTypeDTOValidation : CvDeleteValidation<DeleteExperienceTypeDTO>
    {
        public DeleteExperienceTypeDTOValidation() : base()
        {

        }
    }
}
