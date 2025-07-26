using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Presentation.CvAPI.Controllers.Abstract;
using TahaMucasiroglu.Presentation.API.Controllers.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.CvAPI.Controllers.Base
{
    abstract public class CvController<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : Controller<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, ICvController<TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, ICvEntity
        where TResponse : class, ICvGetDTO
        where TAddRequest : class, ICvAddDTO
        where TUpdateRequest : class, ICvUpdateDTO
        where TDeleteRequest : class, ICvDeleteDTO
    {
        public CvController(IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> service) : base(service)
        {
        }
    }
}
