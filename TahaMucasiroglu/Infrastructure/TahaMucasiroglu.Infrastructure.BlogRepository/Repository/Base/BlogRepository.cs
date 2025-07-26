using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.BlogRepository.Context;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Base
{
    public class BlogRepository<TEntity> : Repository<TEntity>, IBlogRepository<TEntity>
        where TEntity : class, IBlogEntity
    {
        public BlogRepository(BlogTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
