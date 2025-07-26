using TahaMucasiroglu.Domain.DTOs.Abstract.Blog;
using TahaMucasiroglu.Domain.Entities.Abstract;

namespace TahaMucasiroglu.Service.Database.Abstract.Base
{
    public interface IBlogDatabaseService<TEntity, TResponse> : IDatabaseService<TEntity, TResponse>
        where TEntity : class, IBlogEntity
        where TResponse : class, IBlogGetDTO
    {
    }
    public interface IBlogDatabaseService<TEntity, TResponse, TAddRequest> : IDatabaseService<TEntity, TResponse, TAddRequest>
        where TEntity : class, IBlogEntity
        where TResponse : class, IBlogGetDTO
        where TAddRequest : class, IBlogAddDTO
    {
    }
    public interface IBlogDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest>
        where TEntity : class, IBlogEntity
        where TResponse : class, IBlogGetDTO
        where TAddRequest : class, IBlogAddDTO
        where TUpdateRequest : class, IBlogUpdateDTO
    {
    }
    public interface IBlogDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
        where TEntity : class, IBlogEntity
        where TResponse : class, IBlogGetDTO
        where TAddRequest : class, IBlogAddDTO
        where TUpdateRequest : class, IBlogUpdateDTO
        where TDeleteRequest : class, IBlogDeleteDTO
    {
    }
}
