using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;
using TahaMucasiroglu.Presentation.API.Controllers.Abstract;

namespace TahaMucasiroglu.Presentation.P2PMessageAPI.Controllers.Abstract
{
    public interface IP2PMessageController<TAdd, TUpdate, TDelete> : IController<TAdd, TUpdate, TDelete>
        where TAdd : class, IStatisticAddDTO
        where TUpdate : class, IStatisticUpdateDTO
        where TDelete : class, IStatisticDeleteDTO
    {
    }
}
