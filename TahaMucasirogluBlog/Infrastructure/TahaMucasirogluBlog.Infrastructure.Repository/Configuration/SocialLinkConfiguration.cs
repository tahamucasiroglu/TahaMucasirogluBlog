using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Base;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Main;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration
{
    public class SocialLinkConfiguration : EntityConfiguration<SocialLink>
    {
        public override void Configure(EntityTypeBuilder<SocialLink> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(e => e.Url)
                  .IsRequired()
                  .HasMaxLength(500);

            builder.Property(e => e.IconClass)
                  .HasMaxLength(100);

            builder.Property(e => e.DisplayOrder)
                  .HasDefaultValue(0);

            builder.Property(e => e.IsVisible)
                  .HasDefaultValue(true);
        }
    }
}
