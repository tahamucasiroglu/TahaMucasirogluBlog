using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;
using TahaMucasiroglu.Domain.DTOs.Abstract.Statistic;
using TahaMucasiroglu.Presentation.API.Controllers.Abstract;

namespace TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Abstract
{
    public interface IStatisticController<TAdd, TUpdate, TDelete> : IController<TAdd, TUpdate, TDelete>
        where TAdd : class, IStatisticAddDTO
        where TUpdate : class, IStatisticUpdateDTO
        where TDelete : class, IStatisticDeleteDTO
    {
    }
}
