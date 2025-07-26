using TahaMucasiroglu.Domain.DTOs.Abstract.Statistic;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Presentation.API.Controllers.Base;
using TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Abstract;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.StatisticAPI.Controllers.Base
{
    abstract public class StatisticController<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : Controller<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, IStatisticController<TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, IStatisticEntity
        where TResponse : class, IStatisticGetDTO
        where TAddRequest : class, IStatisticAddDTO
        where TUpdateRequest : class, IStatisticUpdateDTO
        where TDeleteRequest : class, IStatisticDeleteDTO
    {
        public StatisticController(IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> service) : base(service)
        {
        }
    }
}
