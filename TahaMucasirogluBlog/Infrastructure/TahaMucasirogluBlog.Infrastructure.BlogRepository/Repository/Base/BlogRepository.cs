using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Context;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Base
{
    public class BlogRepository<TEntity> : Repository<TEntity>, IBlogRepository<TEntity>
        where TEntity : class, IBlogEntity
    {
        public BlogRepository(BlogTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
