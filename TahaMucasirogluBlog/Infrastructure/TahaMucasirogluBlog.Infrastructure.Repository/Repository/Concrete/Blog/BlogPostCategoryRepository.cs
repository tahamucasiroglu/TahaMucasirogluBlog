using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete.Blog
{
    public class BlogPostCategoryRepository : BlogRepository<BlogPostCategory>, IBlogPostCategoryRepository
    {
        public BlogPostCategoryRepository(BlogTahaMucasirogluContext context, ILogger<BlogPostCategoryRepository> logger) : base(context, logger)
        {
        }
    }
}
