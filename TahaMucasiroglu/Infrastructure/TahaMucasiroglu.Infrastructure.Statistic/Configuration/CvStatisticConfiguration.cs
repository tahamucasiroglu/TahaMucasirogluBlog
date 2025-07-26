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
    public class CvStatisticConfiguration : StatisticEntityConfiguration<CvStatistic>
    {
        public override void Configure(EntityTypeBuilder<CvStatistic> builder)
        {
            base.Configure(builder);


        }
    }
}
