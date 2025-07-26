using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Configuration;

namespace TahaMucasiroglu.Infrastructure.P2PMessageRepository.Context
{
    public class P2PMessageTahaMucasirogluContext : DbContext
    {

        public DbSet<P2PMessageStatistic> P2PMessageStatistics { get; set; }



        public P2PMessageTahaMucasirogluContext(DbContextOptions<P2PMessageTahaMucasirogluContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new P2PMessageStatisticConfiguration());
        }
    }
}
