using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Context;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.Repository.BlogRepository.Concrete
{
    public class UserRepository : BlogRepository<User>, IUserRepository
    {
        public UserRepository(BlogTahaMucasirogluContext context, ILogger<UserRepository> logger) : base(context, logger)
        {
        }
    }
}
