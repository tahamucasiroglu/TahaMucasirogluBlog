using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.StatisticDatabase.Abstract
{
    public interface IP2PMessageStatisticDatabaseService : IStatisticDatabaseService<P2PMessageStatistic, GetP2PMessageStatisticDTO, AddP2PMessageStatisticDTO, UpdateP2PMessageStatisticDTO, DeleteP2PMessageStatisticDTO>
    {
    }
}
