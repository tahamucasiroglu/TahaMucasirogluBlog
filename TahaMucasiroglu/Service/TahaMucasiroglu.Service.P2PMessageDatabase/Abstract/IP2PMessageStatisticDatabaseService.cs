using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Service.P2PMessageDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.P2PMessageDatabase.Abstract
{
    public interface IP2PMessageStatisticDatabaseService : IP2PMessageDatabaseService<P2PMessageStatistic, GetP2PMessageStatisticDTO, AddP2PMessageStatisticDTO, UpdateP2PMessageStatisticDTO, DeleteP2PMessageStatisticDTO>
    {
    }
}
