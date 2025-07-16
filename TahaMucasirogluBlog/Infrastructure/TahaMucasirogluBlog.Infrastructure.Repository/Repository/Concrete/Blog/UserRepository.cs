using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete.Blog
{
    public class UserRepository : BlogRepository<User>, IUserRepository
    {
        public UserRepository(BlogTahaMucasirogluContext context, ILogger<UserRepository> logger) : base(context, logger)
        {
        }
    }
}
