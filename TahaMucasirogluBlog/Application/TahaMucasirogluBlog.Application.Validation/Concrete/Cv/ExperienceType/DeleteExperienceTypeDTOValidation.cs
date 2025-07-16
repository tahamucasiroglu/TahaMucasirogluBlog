using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.ExperienceType
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
