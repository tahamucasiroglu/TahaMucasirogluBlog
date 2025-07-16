using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration
{
    public class ExperienceTechnologyConfiguration : CvEntityConfiguration<ExperienceTechnology>
    {
        public override void Configure(EntityTypeBuilder<ExperienceTechnology> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(et => et.Experience)
                .WithMany(e => e.ExperienceTechnologies)
                .HasForeignKey(et => et.ExperienceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(et => et.SubSkill)
                .WithMany()
                .HasForeignKey(et => et.SubSkillId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(et => new { et.ExperienceId, et.SubSkillId }).IsUnique();
        }
    }
}
