using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Tag;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.Tag
{
    public class DeleteTagListDTOValidation : AbstractValidator<IEnumerable<DeleteTagDTO>>
    {
        public DeleteTagListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteTagDTOValidation());
        }
    }
    public class DeleteTagDTOValidation : BlogDeleteValidation<DeleteTagDTO>
    {
        public DeleteTagDTOValidation() : base()
        {
            
        }
    }
}
