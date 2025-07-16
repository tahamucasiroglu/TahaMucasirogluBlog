using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration.Base
{
    public abstract class CvEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, ICvEntity
    {
    }
}
