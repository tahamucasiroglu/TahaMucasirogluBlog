using Microsoft.EntityFrameworkCore;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Configuration;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Context
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
