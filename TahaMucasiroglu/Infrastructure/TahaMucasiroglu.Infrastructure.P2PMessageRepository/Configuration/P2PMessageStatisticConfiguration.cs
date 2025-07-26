using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.P2PMessageRepository.Configuration
{
    public class P2PMessageStatisticConfiguration : P2PMessageEntityConfiguration<P2PMessageStatistic>
    {
        public override void Configure(EntityTypeBuilder<P2PMessageStatistic> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.SessionId)
            .IsRequired();

            builder.Property(e => e.ProcessType)
                .HasConversion<int>() /* enum olarak integer sakla */
                .IsRequired();

            builder.Property(e => e.ProcessDate)
                .HasColumnType("datetime2")
                .IsRequired();

            // IP adresi
            builder.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .IsUnicode(false);

            // User Agent
            builder.Property(e => e.UserAgent)
                .HasMaxLength(512);

            builder.Property(e => e.Browser)
                .HasMaxLength(100);

            builder.Property(e => e.OperatingSystem)
                .HasMaxLength(100);

            builder.Property(e => e.DeviceType)
                .HasMaxLength(50);

            // Coğrafi veriler
            builder.Property(e => e.Latitude)
                .HasColumnType("decimal(9,6)");

            builder.Property(e => e.Longitude)
                .HasColumnType("decimal(9,6)");

            builder.Property(e => e.Country)
                .HasMaxLength(100);

            builder.Property(e => e.Region)
                .HasMaxLength(100);

            builder.Property(e => e.City)
                .HasMaxLength(100);

            // İndeksler — analiz/statistik performansı için faydalı
            builder.HasIndex(e => e.SessionId);
            builder.HasIndex(e => e.ProcessDate);
            builder.HasIndex(e => new { e.Country, e.Region, e.City });
        }
    }
}
