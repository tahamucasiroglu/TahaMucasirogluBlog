using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Presentation.API.Controllers.Base;
using TahaMucasiroglu.Presentation.P2PMessageAPI.Controllers.Abstract;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.P2PMessageAPI.Controllers.Base
{
    abstract public class P2PMessageController<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : Controller<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, IP2PMessageController<TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, IP2PMessageEntity
        where TResponse : class, IP2PMessageGetDTO
        where TAddRequest : class, IStatisticAddDTO
        where TUpdateRequest : class, IStatisticUpdateDTO
        where TDeleteRequest : class, IStatisticDeleteDTO
    {
        public P2PMessageController(IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> service) : base(service)
        {
        }
    }
}
