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
    public class CvRepository<TEntity> : Repository<TEntity>, ICvRepository<TEntity>
        where TEntity : class, ICvEntity
    {
        public CvRepository(CvTahaMucasirogluContext context, ILogger<Repository<TEntity>> logger) : base(context, logger)
        {
        }
    }
}
