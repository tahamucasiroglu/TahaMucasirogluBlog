using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract.Base
{
    public interface IStatisticRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IStatisticEntity
    {
    }
}
