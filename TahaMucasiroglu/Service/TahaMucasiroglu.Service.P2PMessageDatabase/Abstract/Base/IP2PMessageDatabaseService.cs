using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.P2PMessageDatabase.Abstract.Base
{
    public interface IP2PMessageDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, IP2PMessageEntity
        where TResponse : class, IP2PMessageGetDTO
        where TAddRequest : class, IStatisticAddDTO
        where TUpdateRequest : class, IStatisticUpdateDTO
        where TDeleteRequest : class, IStatisticDeleteDTO
    {
    }
}
