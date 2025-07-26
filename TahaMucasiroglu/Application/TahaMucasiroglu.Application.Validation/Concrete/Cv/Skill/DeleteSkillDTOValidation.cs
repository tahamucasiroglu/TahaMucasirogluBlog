using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.Skill
{
    public class DeleteSkillListDTOValidation : AbstractValidator<IEnumerable<DeleteSkillDTO>>
    {
        public DeleteSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteSkillDTOValidation());
        }
    }
    public class DeleteSkillDTOValidation : CvDeleteValidation<DeleteSkillDTO>
    {
        public DeleteSkillDTOValidation() : base()
        {

        }
    }
}
