using TahaMucasirogluBlog.Domain.Entities.Abstract;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base
{
    public interface ICvRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, ICvEntity
    {
    }
}
