using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract.Base
{
    public interface ICvRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, ICvEntity
    {
    }
}
