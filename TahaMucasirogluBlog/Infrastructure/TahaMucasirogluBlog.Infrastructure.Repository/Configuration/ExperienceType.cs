using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration
{
    public class ExperienceTypeConfiguration : EntityConfiguration<ExperienceType>
    {
        public override void Configure(EntityTypeBuilder<ExperienceType> builder)
        {
            base.Configure(builder);

            builder.Property(et => et.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(et => et.Name).IsUnique();
        }
    }
}
