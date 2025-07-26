using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Presentation.P2PMessageAPI.Controllers.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;
using TahaMucasiroglu.Service.P2PMessageDatabase.Abstract;

namespace TahaMucasiroglu.Presentation.P2PMessageAPI.Controllers.Concrete
{
    public class StatisticController : P2PMessageController<P2PMessageStatistic, GetP2PMessageStatisticDTO, AddP2PMessageStatisticDTO, UpdateP2PMessageStatisticDTO, DeleteP2PMessageStatisticDTO>
    {
        public StatisticController(IP2PMessageStatisticDatabaseService service) : base(service)
        {
        }
    }
}
