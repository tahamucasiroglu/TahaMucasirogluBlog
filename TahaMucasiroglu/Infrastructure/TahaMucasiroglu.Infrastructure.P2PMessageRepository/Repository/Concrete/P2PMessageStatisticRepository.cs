using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Context;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Base;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Concrete
{
    public class P2PMessageStatisticRepository : P2PMessageRepository<P2PMessageStatistic>, IP2PMessageStatisticRepository
    {
        public P2PMessageStatisticRepository(P2PMessageTahaMucasirogluContext context, ILogger<P2PMessageStatisticRepository> logger) : base(context, logger)
        {
        }
    }
}
