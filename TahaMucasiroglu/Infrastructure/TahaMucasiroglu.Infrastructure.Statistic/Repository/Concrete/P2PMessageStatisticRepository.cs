using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Context;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Concrete
{
    public class P2PMessageStatisticRepository : StatisticRepository<P2PMessageStatistic>, IP2PMessageStatisticRepository
    {
        public P2PMessageStatisticRepository(StatisticTahaMucasirogluContext context, ILogger<P2PMessageStatisticRepository> logger) : base(context, logger)
        {
        }
    }
}
