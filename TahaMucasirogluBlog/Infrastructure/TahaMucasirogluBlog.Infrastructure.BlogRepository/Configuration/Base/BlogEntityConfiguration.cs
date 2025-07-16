using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.BlogRepository.Configuration.Base
{
    public abstract class BlogEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, IBlogEntity
    {
        
    }
}
