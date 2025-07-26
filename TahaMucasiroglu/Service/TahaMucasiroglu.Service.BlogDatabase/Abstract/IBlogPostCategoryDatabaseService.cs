using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Abstract
{
    public interface IBlogPostCategoryDatabaseService : IBlogDatabaseService<BlogPostCategory, GetBlogPostCategoryDTO, AddBlogPostCategoryDTO, UpdateBlogPostCategoryDTO, DeleteBlogPostCategoryDTO>
    {
    }
}
