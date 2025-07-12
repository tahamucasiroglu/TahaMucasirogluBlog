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
    public class SubSkillConfiguration : EntityConfiguration<SubSkill>
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
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ss => new { ss.SkillId, ss.Name }).IsUnique();
        }
    }
}
