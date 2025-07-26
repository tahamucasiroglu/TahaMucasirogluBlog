using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Configuration
{
    public class SubSkillConfiguration : CvEntityConfiguration<SubSkill>
    {
        public override void Configure(EntityTypeBuilder<SubSkill> builder)
        {
            base.Configure(builder);

            builder.Property(ss => ss.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder
                .HasOne<Skill>()
                .WithMany(s => s.SubSkills)
                .HasForeignKey(ss => ss.SkillId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(ss => new { ss.SkillId, ss.Name }).IsUnique();
        }
    }
}
