using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Skill
{
    public class DeleteSkillListDTOValidation : AbstractValidator<IEnumerable<DeleteSkillDTO>>
    {
        public DeleteSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteSkillDTOValidation());
        }
    }
    public class DeleteSkillDTOValidation : DeleteValidation<DeleteSkillDTO>
    {
        public DeleteSkillDTOValidation() : base()
        {
            
        }
    }
}
