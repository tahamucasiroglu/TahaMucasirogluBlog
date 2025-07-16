using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Context;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.BlogRepository.Concrete
{
    public class CommentRepository : BlogRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogTahaMucasirogluContext context, ILogger<CommentRepository> logger) : base(context, logger)
        {
        }
    }
}
