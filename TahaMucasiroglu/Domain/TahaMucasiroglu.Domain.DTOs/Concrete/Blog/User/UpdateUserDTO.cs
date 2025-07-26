using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;
using TahaMucasiroglu.Domain.DTOs.Base.Blog;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Blog.User
{
    public record UpdateUserDTO : BlogUpdateDTO
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PasswordHash { get; init; } = string.Empty;
    }
}
