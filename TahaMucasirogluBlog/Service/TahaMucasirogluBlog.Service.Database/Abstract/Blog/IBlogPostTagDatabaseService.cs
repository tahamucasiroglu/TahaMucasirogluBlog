using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostTag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Blog
{
    public interface IBlogPostTagDatabaseService : IBlogDatabaseService<BlogPostTag, GetBlogPostTagDTO, AddBlogPostTagDTO, UpdateBlogPostTagDTO, DeleteBlogPostTagDTO>
    {
    }
}
