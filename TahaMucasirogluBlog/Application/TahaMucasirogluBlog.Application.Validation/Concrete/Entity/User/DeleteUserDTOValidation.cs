using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.User;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.User
{
    public class DeleteUserDTOValidation : DeleteValidation<DeleteUserDTO>
    {
        public DeleteUserDTOValidation() : base()
        {
            
        }
    }
}
