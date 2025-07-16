using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration
{
    public class InfoConfiguration : CvEntityConfiguration<Info>
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
