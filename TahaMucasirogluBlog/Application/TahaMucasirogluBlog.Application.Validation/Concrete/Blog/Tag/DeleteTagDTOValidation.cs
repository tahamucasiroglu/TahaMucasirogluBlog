using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Tag;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.Tag
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
