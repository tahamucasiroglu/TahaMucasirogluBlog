using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.SubSkill
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
