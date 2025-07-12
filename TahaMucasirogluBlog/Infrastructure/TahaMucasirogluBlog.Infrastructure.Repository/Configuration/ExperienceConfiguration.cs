using Microsoft.EntityFrameworkCore;
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
    public class ExperienceConfiguration : EntityConfiguration<Experience>
    {
        public override void Configure(EntityTypeBuilder<Experience> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(e => e.ExperienceType)
                .WithMany()
                .HasForeignKey(e => e.ExperienceTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Provider)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Description)
                   .IsRequired();

            builder.Property(e => e.Reference)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.HasIndex(e => e.ExperienceTypeId);
        }
    }
}
