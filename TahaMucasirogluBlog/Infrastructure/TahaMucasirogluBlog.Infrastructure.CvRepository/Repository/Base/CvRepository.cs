using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Context;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Base
{
    public class CvRepository<TEntity> : Repository<TEntity>, ICvRepository<TEntity>
        where TEntity : class, ICvEntity
    {
        public CvRepository(CvTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
