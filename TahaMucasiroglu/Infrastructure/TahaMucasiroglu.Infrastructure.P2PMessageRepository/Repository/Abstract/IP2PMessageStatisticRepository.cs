using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract.Base;

namespace TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract
{
    public interface IP2PMessageStatisticRepository : IP2PMessageRepository<P2PMessageStatistic>
    {
    }
}
