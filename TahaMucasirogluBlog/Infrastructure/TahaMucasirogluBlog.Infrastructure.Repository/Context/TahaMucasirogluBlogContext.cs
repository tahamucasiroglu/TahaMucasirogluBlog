using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Context
{
    public class TahaMucasirogluBlogContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostCategory> BlogPostsCategory { get; set; }
        public DbSet<BlogPostTag> BlogPostsTag { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment>Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }

        

        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceTechnology> ExperienceTechnologies { get; set; }
        public DbSet<ExperienceType> ExperienceTypes { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SubSkill> SubSkills { get; set; }



        public TahaMucasirogluBlogContext(DbContextOptions<TahaMucasirogluBlogContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new BlogPostCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostTagConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SocialLinkConfiguration());

            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceTechnologyConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InfoConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new SubSkillConfiguration());
        }
    }
}
