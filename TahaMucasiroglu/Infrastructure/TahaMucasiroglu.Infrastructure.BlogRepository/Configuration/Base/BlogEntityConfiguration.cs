using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Configuration.Base
{
    public abstract class BlogEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, IBlogEntity
    {
        
    }
}
