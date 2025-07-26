using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceTechnology
{
    public class DeleteExperienceTechnologyListDTOValidation : AbstractValidator<IEnumerable<DeleteExperienceTechnologyDTO>>
    {
        public DeleteExperienceTechnologyListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteExperienceTechnologyDTOValidation());
        }
    }
    public class DeleteExperienceTechnologyDTOValidation : CvDeleteValidation<DeleteExperienceTechnologyDTO>
    {
        public DeleteExperienceTechnologyDTOValidation() : base()
        {
            
        }
    }
}
