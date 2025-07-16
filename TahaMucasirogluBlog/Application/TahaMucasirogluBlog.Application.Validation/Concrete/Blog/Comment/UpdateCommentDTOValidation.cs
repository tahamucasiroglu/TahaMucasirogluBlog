using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Comment;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.Comment
{
    public class UpdateCommentListDTOValidation : AbstractValidator<IEnumerable<UpdateCommentDTO>>
    {
        public UpdateCommentListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateCommentDTOValidation());
        }
    }
    public class UpdateCommentDTOValidation : BlogUpdateValidation<UpdateCommentDTO>
    {
        public UpdateCommentDTOValidation() : base()
        {
            RuleFor(x => x.PostId)
            .NotEmpty()
            .WithMessage("PostId boş olamaz."); // Guid.Empty kontrolü

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("İçerik boş olamaz.")
                .MinimumLength(5)
                .WithMessage("İçerik en az 5 karakter olmalı.")
                .MaximumLength(2000)
                .WithMessage("İçerik en fazla 2000 karakter olabilir.");

            RuleFor(x => x.ParentCommentId)
                .Must(id => id == null || id != Guid.Empty)
                .WithMessage("ParentCommentId geçerli bir GUID olmalı veya null kalmalı.");
        }
    }
}
