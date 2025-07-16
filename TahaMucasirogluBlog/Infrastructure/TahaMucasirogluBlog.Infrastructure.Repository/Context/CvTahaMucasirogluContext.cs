using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Cv;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Context
{
    public class CvTahaMucasirogluContext : DbContext
    {
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceTechnology> ExperienceTechnologies { get; set; }
        public DbSet<ExperienceType> ExperienceTypes { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SubSkill> SubSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceTechnologyConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InfoConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new SubSkillConfiguration());
        }
    }
}
