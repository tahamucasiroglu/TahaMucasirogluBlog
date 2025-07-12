using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration
{
    public class InfoConfiguration : EntityConfiguration<Info>
    {
        public override void Configure(EntityTypeBuilder<Info> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(i => i.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(i => i.Phone)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(i => i.Location)
                   .IsRequired()
                   .HasMaxLength(200);

        }
    }
}
