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
    public class ExperienceTechnologyConfiguration : EntityConfiguration<ExperienceTechnology>
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
