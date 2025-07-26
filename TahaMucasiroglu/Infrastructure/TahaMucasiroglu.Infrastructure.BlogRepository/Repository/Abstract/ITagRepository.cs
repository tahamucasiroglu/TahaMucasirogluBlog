using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract
{
    public interface ITagRepository : IBlogRepository<Tag>
    {
    }
}
