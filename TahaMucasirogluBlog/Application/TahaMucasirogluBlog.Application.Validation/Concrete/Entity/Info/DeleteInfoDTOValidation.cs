using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Info
{
    public class DeleteInfoListDTOValidation : AbstractValidator<IEnumerable<DeleteInfoDTO>>
    {
        public DeleteInfoListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteInfoDTOValidation());
        }
    }
    public class DeleteInfoDTOValidation : DeleteValidation<DeleteInfoDTO>
    {
        public DeleteInfoDTOValidation() : base()
        {
            
        }
    }
}
