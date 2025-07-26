using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Configuration
{
    public class P2PMessageStatisticConfiguration : StatisticEntityConfiguration<P2PMessageStatistic>
    {
        public override void Configure(EntityTypeBuilder<P2PMessageStatistic> builder)
    {
        base.Configure(builder);


    }
}
}
