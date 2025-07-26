using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.CvRepository.Context;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Repository.Base
{
    public class CvRepository<TEntity> : Repository<TEntity>, ICvRepository<TEntity>
        where TEntity : class, ICvEntity
    {
        public CvRepository(CvTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
