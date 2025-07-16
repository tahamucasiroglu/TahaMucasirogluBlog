using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.ExperienceTechnology
{
    public class DeleteExperienceTechnologyListDTOValidation : AbstractValidator<IEnumerable<DeleteExperienceTechnologyDTO>>
    {
        public DeleteExperienceTechnologyListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteExperienceTechnologyDTOValidation());
        }
    }
    public class DeleteExperienceTechnologyDTOValidation : DeleteValidation<DeleteExperienceTechnologyDTO>
    {
        public DeleteExperienceTechnologyDTOValidation() : base()
        {
            
        }
    }
}
