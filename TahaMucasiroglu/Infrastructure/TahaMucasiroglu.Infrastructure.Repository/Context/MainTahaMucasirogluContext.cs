using Microsoft.EntityFrameworkCore;
using TahaMucasiroglu.Domain.Entities.Concrete.Main;
using TahaMucasiroglu.Infrastructure.Repository.Configuration;

namespace TahaMucasiroglu.Infrastructure.Repository.Context
{
    public class MainTahaMucasirogluContext : DbContext
    {

        public DbSet<SocialLink> SocialLinks { get; set; }


        public MainTahaMucasirogluContext(DbContextOptions<MainTahaMucasirogluContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new SocialLinkConfiguration());
        }
    }
}
