using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract.Base
{
    public interface IBlogRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBlogEntity
    {
    }
}
