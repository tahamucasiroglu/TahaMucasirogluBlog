using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.User;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.User
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
