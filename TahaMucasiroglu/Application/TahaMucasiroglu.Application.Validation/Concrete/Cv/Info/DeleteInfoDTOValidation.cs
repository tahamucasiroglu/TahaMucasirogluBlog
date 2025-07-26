using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.Info
{
    public class DeleteInfoListDTOValidation : AbstractValidator<IEnumerable<DeleteInfoDTO>>
    {
        public DeleteInfoListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteInfoDTOValidation());
        }
    }
    public class DeleteInfoDTOValidation : CvDeleteValidation<DeleteInfoDTO>
    {
        public DeleteInfoDTOValidation() : base()
        {

        }
    }
}
