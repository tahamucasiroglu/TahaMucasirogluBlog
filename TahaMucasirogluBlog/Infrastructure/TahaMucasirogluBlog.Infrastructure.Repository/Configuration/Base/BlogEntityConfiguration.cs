using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Abstract;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base
{
    public abstract class BlogEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, IBlogEntity
    {
        
    }
}
