using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Context;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.BlogRepository.Concrete
{
    public class TagRepository : BlogRepository<Tag>, ITagRepository
    {
        public TagRepository(BlogTahaMucasirogluContext context, ILogger<TagRepository> logger) : base(context, logger)
        {
        }
    }
}
