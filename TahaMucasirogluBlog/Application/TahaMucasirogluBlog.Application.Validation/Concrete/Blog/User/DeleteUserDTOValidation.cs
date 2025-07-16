using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Base.Blog;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.User;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Blog.User
{
    public class DeleteUserListDTOValidation : AbstractValidator<IEnumerable<DeleteUserDTO>>
    {
        public DeleteUserListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteUserDTOValidation());
        }
    }
    public class DeleteUserDTOValidation : BlogDeleteValidation<DeleteUserDTO>
    {
        public DeleteUserDTOValidation() : base()
        {
            
        }
    }
}
