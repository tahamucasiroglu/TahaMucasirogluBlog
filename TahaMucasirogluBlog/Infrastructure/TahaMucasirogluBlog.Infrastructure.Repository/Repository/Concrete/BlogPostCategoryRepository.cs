using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete
{
    public class BlogPostCategoryRepository : Repository<BlogPostCategory>, IBlogPostCategoryRepository
    {
        public BlogPostCategoryRepository(TahaMucasirogluBlogContext context, ILogger<BlogPostCategoryRepository> logger) : base(context, logger)
        {
        }
    }
}
