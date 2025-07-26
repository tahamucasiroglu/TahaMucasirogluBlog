using Microsoft.EntityFrameworkCore;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Configuration;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Context
{
    public class StatisticTahaMucasirogluContext : DbContext
    {
        public DbSet<P2PMessageStatistic> P2PMessageStatistics { get; set; }
        public DbSet<CvStatistic> CvStatistics { get; set; }


        public StatisticTahaMucasirogluContext(DbContextOptions<StatisticTahaMucasirogluContext> options)
        : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");


            modelBuilder.ApplyConfiguration(new CvStatisticConfiguration());
            modelBuilder.ApplyConfiguration(new P2PMessageStatisticConfiguration());
        }
    }
}
