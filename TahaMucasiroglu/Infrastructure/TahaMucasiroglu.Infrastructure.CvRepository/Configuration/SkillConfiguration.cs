using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Configuration
{
    public class SkillConfiguration : CvEntityConfiguration<Skill>
    {
        public override void Configure(EntityTypeBuilder<Skill> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(s => s.Name).IsUnique();
        }
    }
}
