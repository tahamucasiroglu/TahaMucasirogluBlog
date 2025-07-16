using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.BlogDatabase.Abstract
{
    public interface IBlogPostCategoryDatabaseService : IBlogDatabaseService<BlogPostCategory, GetBlogPostCategoryDTO, AddBlogPostCategoryDTO, UpdateBlogPostCategoryDTO, DeleteBlogPostCategoryDTO>
    {
    }
}
