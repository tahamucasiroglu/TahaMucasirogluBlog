using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Configuration
{
    public class ExperienceTypeConfiguration : CvEntityConfiguration<ExperienceType>
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
