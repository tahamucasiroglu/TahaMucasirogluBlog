using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Info
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
