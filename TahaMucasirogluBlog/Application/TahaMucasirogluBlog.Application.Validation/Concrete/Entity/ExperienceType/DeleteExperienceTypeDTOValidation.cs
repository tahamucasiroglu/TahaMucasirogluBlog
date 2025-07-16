using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.ExperienceType
{
    public class DeleteExperienceTypeListDTOValidation : AbstractValidator<IEnumerable<DeleteExperienceTypeDTO>>
    {
        public DeleteExperienceTypeListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteExperienceTypeDTOValidation());
        }
    }
    public class DeleteExperienceTypeDTOValidation : DeleteValidation<DeleteExperienceTypeDTO>
    {
        public DeleteExperienceTypeDTOValidation() : base()
        {
            
        }
    }
}
