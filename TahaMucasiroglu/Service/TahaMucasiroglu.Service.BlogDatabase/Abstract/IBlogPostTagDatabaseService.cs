using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostTag;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Abstract
{
    public interface IBlogPostTagDatabaseService : IBlogDatabaseService<BlogPostTag, GetBlogPostTagDTO, AddBlogPostTagDTO, UpdateBlogPostTagDTO, DeleteBlogPostTagDTO>
    {
    }
}
