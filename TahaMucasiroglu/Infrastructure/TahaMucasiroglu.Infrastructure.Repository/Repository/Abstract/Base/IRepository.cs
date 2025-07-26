using System.Linq.Expressions;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Domain.Return.Abstract;

namespace TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base
{
    public interface IRepository<TEntity> : IDisposable, IAsyncDisposable
        where TEntity : class, IEntity
    {



        /// <summary>
        /// Filtreye uyan tek bir entity’i, Include’larıyla birlikte getirir.
        /// </summary>
        Task<IReturn<TEntity>> GetWithIncludesAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Filtreye uyan tek bir entity’i, Include’larıyla birlikte getirir.
        /// </summary>
        IReturn<TEntity> GetWithIncludes(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);


        /// <summary>
        /// Filtreye uyan tüm entity’leri, Include’larıyla birlikte getirir.
        /// </summary>
        Task<IReturn<List<TEntity>>> GetAllWithIncludesAsync(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);


        /// <summary>
        /// Filtreye uyan tüm entity’leri, Include’larıyla birlikte getirir.
        /// </summary>
        IReturn<List<TEntity>> GetAllWithIncludes(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);


        public IReturn<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        public IReturn<TEntity> GetLast(Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<TEntity>> GetLastAsync(Expression<Func<TEntity, bool>> filter);

        public IReturn<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);
        public Task<IReturn<IEnumerable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);

        public IReturn<TEntity> GetDeleted(Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<TEntity>> GetDeletedAsync(Expression<Func<TEntity, bool>> filter);

        public IReturn<IEnumerable<TEntity>> GetAllDeleted(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);
        public Task<IReturn<IEnumerable<TEntity>>> GetAllDeletedAsync(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false);

        public IReturn<int> Count(Expression<Func<TEntity, bool>>? filter = null);
        public Task<IReturn<int>> CountAsync(Expression<Func<TEntity, bool>>? filter = null);

        public IReturn<bool> IsExist(Expression<Func<TEntity, bool>> filter);
        public Task<IReturn<bool>> IsExistAsync(Expression<Func<TEntity, bool>> filter);

        public IReturn<TEntity> Add(TEntity entity);
        public IReturn<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entity);
        public Task<IReturn<TEntity>> AddAsync(TEntity entity);
        public Task<IReturn<IEnumerable<TEntity>>> AddAsync(IEnumerable<TEntity> entity);

        public IReturn<TEntity> Update(TEntity entity);
        public IReturn<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity);
        public Task<IReturn<TEntity>> UpdateAsync(TEntity entity);
        public Task<IReturn<IEnumerable<TEntity>>> UpdateAsync(IEnumerable<TEntity> entity);

        public IReturn<TEntity> Delete(TEntity entity);
        public IReturn<IEnumerable<TEntity>> Delete(IEnumerable<TEntity> entity);
        public Task<IReturn<TEntity>> DeleteAsync(TEntity entity);
        public Task<IReturn<IEnumerable<TEntity>>> DeleteAsync(IEnumerable<TEntity> entity);

        public IReturn<TEntity> Save(TEntity entity);
        public IReturn<IEnumerable<TEntity>> Save(IEnumerable<TEntity> entity);
        public Task<IReturn<TEntity>> SaveAsync(TEntity entity);
        public Task<IReturn<IEnumerable<TEntity>>> SaveAsync(IEnumerable<TEntity> entity);

        public IReturn<TNull> CheckIsNull<TNull>(TNull? result);
        public IReturn<TNull> ErrorReturn<TNull>(Exception e);

        public void BeginTransaction();
        public Task BeginTransactionAsync();
        public void Commit();
        public Task CommitAsync();
        public void Rollback();
        public Task RollbackAsync();
    }
}
