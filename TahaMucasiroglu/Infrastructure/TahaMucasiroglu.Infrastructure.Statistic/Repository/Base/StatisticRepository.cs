using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Context;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Base
{
    public class StatisticRepository<TEntity> : Repository<TEntity>, IStatisticRepository<TEntity>
        where TEntity : class, IStatisticEntity
    {
        public StatisticRepository(StatisticTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
