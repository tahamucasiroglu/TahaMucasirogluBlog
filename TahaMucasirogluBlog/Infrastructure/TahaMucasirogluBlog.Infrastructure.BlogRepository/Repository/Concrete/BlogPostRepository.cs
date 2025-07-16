using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Context;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.BlogRepository.Concrete
{
    public class BlogPostRepository : BlogRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BlogTahaMucasirogluContext context, ILogger<BlogPostRepository> logger) : base(context, logger)
        {
        }
    }
}
