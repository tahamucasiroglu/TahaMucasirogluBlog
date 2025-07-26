using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Configuration.Base
{
    public abstract class StatisticEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, IStatisticEntity
    {
    }
}
