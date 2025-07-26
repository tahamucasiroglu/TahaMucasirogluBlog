using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Comment;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.Comment
{
    public class DeleteCommentListDTOValidation : AbstractValidator<IEnumerable<DeleteCommentDTO>>
    {
        public DeleteCommentListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteCommentDTOValidation());
        }
    }
    public class DeleteCommentDTOValidation : BlogDeleteValidation<DeleteCommentDTO>
    {
        public DeleteCommentDTOValidation() : base()
        {
            

        }
    }
}
