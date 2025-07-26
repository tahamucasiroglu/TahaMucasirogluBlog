using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Context;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.Repository.BlogRepository.Concrete
{
    public class BlogPostRepository : BlogRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BlogTahaMucasirogluContext context, ILogger<BlogPostRepository> logger) : base(context, logger)
        {
        }
    }
}
