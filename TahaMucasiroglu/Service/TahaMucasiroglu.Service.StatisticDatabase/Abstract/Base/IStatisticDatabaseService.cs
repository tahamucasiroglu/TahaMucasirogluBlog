

using TahaMucasiroglu.Domain.DTOs.Abstract.Statistic;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.StatisticDatabase.Abstract.Base
{
    public interface IStatisticDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, IStatisticEntity
        where TResponse : class, IStatisticGetDTO
        where TAddRequest : class, IStatisticAddDTO
        where TUpdateRequest : class, IStatisticUpdateDTO
        where TDeleteRequest : class, IStatisticDeleteDTO
    {
    }
}
