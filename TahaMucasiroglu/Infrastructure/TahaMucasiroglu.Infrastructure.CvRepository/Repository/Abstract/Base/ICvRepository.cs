using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract.Base
{
    public interface ICvRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, ICvEntity
    {
    }
}
