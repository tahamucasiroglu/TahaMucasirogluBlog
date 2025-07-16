using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Cv;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Experience
{
    public class DeleteExperienceListDTOValidation : AbstractValidator<IEnumerable<DeleteExperienceDTO>>
    {
        public DeleteExperienceListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteExperienceDTOValidation());
        }
    }
    public class DeleteExperienceDTOValidation : CvDeleteValidation<DeleteExperienceDTO>
    {
        public DeleteExperienceDTOValidation() : base()
        {
            
        }
    }
}
