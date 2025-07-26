using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Configuration.Base
{
    public abstract class CvEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, ICvEntity
    {
    }
}
