using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract.Base;

namespace TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract
{
    public interface IBlogPostCategoryRepository : IBlogRepository<BlogPostCategory>
    {
    }
}
