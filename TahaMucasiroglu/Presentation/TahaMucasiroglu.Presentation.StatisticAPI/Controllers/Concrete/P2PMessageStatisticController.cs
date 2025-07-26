using Microsoft.AspNetCore.Mvc;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Base;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract;

namespace TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class P2PMessageStatisticController : StatisticController<P2PMessageStatistic, GetP2PMessageStatisticDTO, AddP2PMessageStatisticDTO, UpdateP2PMessageStatisticDTO, DeleteP2PMessageStatisticDTO>
    {
        public P2PMessageStatisticController(IP2PMessageStatisticDatabaseService service) : base(service)
        {
        }
    }
}
