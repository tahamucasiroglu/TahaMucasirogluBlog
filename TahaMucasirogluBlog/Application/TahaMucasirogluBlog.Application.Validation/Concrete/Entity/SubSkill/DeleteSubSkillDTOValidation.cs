using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SubSkill;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.SubSkill
{
    public class DeleteSubSkillListDTOValidation : AbstractValidator<IEnumerable<DeleteSubSkillDTO>>
    {
        public DeleteSubSkillListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteSubSkillDTOValidation());
        }
    }
    public class DeleteSubSkillDTOValidation : DeleteValidation<DeleteSubSkillDTO>
    {
        public DeleteSubSkillDTOValidation() : base()
        {
            
        }
    }
}
