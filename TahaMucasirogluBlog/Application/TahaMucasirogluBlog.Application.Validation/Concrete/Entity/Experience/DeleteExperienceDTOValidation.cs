using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Experience
{
    public class DeleteExperienceListDTOValidation : AbstractValidator<IEnumerable<DeleteExperienceDTO>>
    {
        public DeleteExperienceListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteExperienceDTOValidation());
        }
    }
    public class DeleteExperienceDTOValidation : DeleteValidation<DeleteExperienceDTO>
    {
        public DeleteExperienceDTOValidation() : base()
        {
            
        }
    }
}
