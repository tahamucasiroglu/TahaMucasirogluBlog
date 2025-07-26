

using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Abstract.Base
{
    public interface ICvDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, ICvEntity
        where TResponse : class, ICvGetDTO
        where TAddRequest : class, ICvAddDTO
        where TUpdateRequest : class, ICvUpdateDTO
        where TDeleteRequest : class, ICvDeleteDTO
    {
    }
}
