using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Skill
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
