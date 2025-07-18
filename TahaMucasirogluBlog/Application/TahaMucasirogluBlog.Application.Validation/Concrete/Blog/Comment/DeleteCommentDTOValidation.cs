﻿using FluentValidation;
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
