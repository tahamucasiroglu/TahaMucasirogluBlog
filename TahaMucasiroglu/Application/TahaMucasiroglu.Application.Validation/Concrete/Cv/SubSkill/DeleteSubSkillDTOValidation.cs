using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.SubSkill
{
    public class DeleteSubSkillListDTOValidation : AbstractValidator<IEnumerable<DeleteSubSkillDTO>>
    {
        public DeleteSubSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteSubSkillDTOValidation());
        }
    }
    public class DeleteSubSkillDTOValidation : CvDeleteValidation<DeleteSubSkillDTO>
    {
        public DeleteSubSkillDTOValidation() : base()
        {

        }
    }
}
