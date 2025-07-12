using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Comment;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Comment
{
    public class DeleteCommentListDTOValidation : AbstractValidator<IEnumerable<DeleteCommentDTO>>
    {
        public DeleteCommentListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteCommentDTOValidation());
        }
    }
    public class DeleteCommentDTOValidation : DeleteValidation<DeleteCommentDTO>
    {
        public DeleteCommentDTOValidation() : base()
        {
            

        }
    }
}
