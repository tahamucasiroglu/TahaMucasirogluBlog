using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Abstract;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base
{
    public interface IBlogRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBlogEntity
    {
    }
}
