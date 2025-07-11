using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Request;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Domain.Return.Abstract;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Base
{

    public interface IDatabaseService<TEntity, TResponse> : IDisposable, IAsyncDisposable
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
    {
        public IReturn<TResponse> GetById(IdRequest model) => Get(model, e => e.Id == model.Id);
        public Task<IReturn<TResponse>> GetByIdAsync(IdRequest model) => GetAsync(model, e => e.Id == model.Id);

        public IReturn<TResponse> Get(IdRequest model, Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<TResponse>> GetAsync(IdRequest model, Expression<Func<TEntity, bool>> filter);

        public IReturn<IEnumerable<TResponse>> GetAll(IdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);
        public Task<IReturn<IEnumerable<TResponse>>> GetAllAsync(IdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);

        public IReturn<IEnumerable<TResponse>> GetAllDeleted(IdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);
        public Task<IReturn<IEnumerable<TResponse>>> GetAllDeletedAsync(IdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);

        public IReturn<TResponse> GetDeleted(IdRequest model, Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<TResponse>> GetDeletedAsync(IdRequest model, Expression<Func<TEntity, bool>> filter);

        public IReturn<int> Count(IdRequest model, Expression<Func<TEntity, bool>>? filter = null);
        public Task<IReturn<int>> CountAsync(IdRequest model, Expression<Func<TEntity, bool>>? filter = null);

        public IReturn<bool> IsExist(IdRequest model, Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<bool>> IsExistAsync(IdRequest model, Expression<Func<TEntity, bool>> filter);
    }

    public interface IDatabaseService<TEntity, TResponse, TAddRequest> : IDatabaseService<TEntity, TResponse>
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
    {

        public IReturn<TResponse> Add(TAddRequest entity);
        public IReturn<IEnumerable<TResponse>> Add(IEnumerable<TAddRequest> entity);
        public Task<IReturn<TResponse>> AddAsync(TAddRequest entity);
        public Task<IReturn<IEnumerable<TResponse>>> AddAsync(IEnumerable<TAddRequest> entity);


    }

    public interface IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest> : IDatabaseService<TEntity, TResponse, TAddRequest>
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
        where TUpdateRequest : class, IUpdateDTO
    {

        public IReturn<TResponse> Update(TUpdateRequest entity);
        public IReturn<IEnumerable<TResponse>> Update(IEnumerable<TUpdateRequest> entity);
        public Task<IReturn<TResponse>> UpdateAsync(TUpdateRequest entity);
        public Task<IReturn<IEnumerable<TResponse>>> UpdateAsync(IEnumerable<TUpdateRequest> entity);

    }


    public interface IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest>
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
        where TUpdateRequest : class, IUpdateDTO
        where TDeleteRequest : class, IDeleteDTO
    {

        public IReturn<TResponse> Delete(TDeleteRequest model);
        public IReturn<IEnumerable<TResponse>> Delete(IEnumerable<TDeleteRequest> model);
        public Task<IReturn<TResponse>> DeleteAsync(TDeleteRequest model);
        public Task<IReturn<IEnumerable<TResponse>>> DeleteAsync(IEnumerable<TDeleteRequest> model);


    }
}
