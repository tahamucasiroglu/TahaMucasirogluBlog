using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base
{
    public class BlogRepository<TEntity> : Repository<TEntity>, IBlogRepository<TEntity>
        where TEntity : class, IBlogEntity
    {
        public BlogRepository(BlogTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
