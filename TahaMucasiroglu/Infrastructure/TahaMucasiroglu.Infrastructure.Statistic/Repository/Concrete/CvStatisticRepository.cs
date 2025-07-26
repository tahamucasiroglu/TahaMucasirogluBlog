using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Context;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Concrete
{
    public class CvStatisticRepository : StatisticRepository<CvStatistic>, ICvStatisticRepository
    {
        public CvStatisticRepository(StatisticTahaMucasirogluContext context, ILogger<CvStatisticRepository> logger) : base(context, logger)
        {
        }
    }
}
