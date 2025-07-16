

using TahaMucasirogluBlog.Domain.DTOs.Abstract.Cv;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluCv.Service.CvDatabase.Abstract.Base
{
    public interface ICvDatabaseService<TEntity, TResponse> : IDatabaseService<TEntity, TResponse>
        where TEntity : class, ICvEntity
        where TResponse : class, ICvGetDTO
    {
    }
    public interface ICvDatabaseService<TEntity, TResponse, TAddRequest> : IDatabaseService<TEntity, TResponse, TAddRequest>
        where TEntity : class, ICvEntity
        where TResponse : class, ICvGetDTO
        where TAddRequest : class, ICvAddDTO
    {
    }
    public interface ICvDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest>
        where TEntity : class, ICvEntity
        where TResponse : class, ICvGetDTO
        where TAddRequest : class, ICvAddDTO
        where TUpdateRequest : class, ICvUpdateDTO
    {
    }
    public interface ICvDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, ICvEntity
        where TResponse : class, ICvGetDTO
        where TAddRequest : class, ICvAddDTO
        where TUpdateRequest : class, ICvUpdateDTO
        where TDeleteRequest : class, ICvDeleteDTO
    {
    }
}
