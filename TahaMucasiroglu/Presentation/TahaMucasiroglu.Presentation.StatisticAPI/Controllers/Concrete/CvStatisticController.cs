using Microsoft.AspNetCore.Mvc;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Base;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract;

namespace TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvStatisticController : StatisticController<CvStatistic, GetCvStatisticDTO, AddCvStatisticDTO, UpdateCvStatisticDTO, DeleteCvStatisticDTO>
    {
        public CvStatisticController(ICvStatisticDatabaseService service) : base(service)
        {
        }
    }
}
