using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration
{
    public class ExperienceConfiguration : CvEntityConfiguration<Experience>
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
