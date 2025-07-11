using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Domain.Extensions;
using TahaMucasirogluBlog.Domain.Return.Abstract;
using TahaMucasirogluBlog.Domain.Return.Concrete;
using TahaMucasirogluBlog.Domain.Return.Constant;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public readonly DbContext context;
        public readonly ILogger<Repository<TEntity>> logger;
        internal IDbContextTransaction? transaction;
        public Repository(TahaMucasirogluBlogContext context, ILogger<Repository<TEntity>> logger)
        {
            this.context = context;
            this.logger = logger;
        }





        #region Includes

        public virtual async Task<IReturn<TEntity>> GetWithIncludesAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
                if (filter != null) query = query.Where(filter);
                foreach (var include in includes) query = query.Include(include);
                return CheckIsNull(await query.FirstOrDefaultAsync());
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual IReturn<TEntity> GetWithIncludes(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
                if (filter != null) query = query.Where(filter);
                foreach (var include in includes) query = query.Include(include);
                return CheckIsNull(query.FirstOrDefault());
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<List<TEntity>>> GetAllWithIncludesAsync(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
                if (filter != null) query = query.Where(filter);
                foreach (var include in includes) query = query.Include(include);
                return CheckIsNull(await query.ToListAsync());
            }
            catch (Exception e)
            {
                return ErrorReturn<List<TEntity>>(e);
            }
        }

        public virtual IReturn<List<TEntity>> GetAllWithIncludes(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
                if (filter != null) query = query.Where(filter);
                foreach (var include in includes) query = query.Include(include);
                return CheckIsNull(query.ToList());
            }
            catch (Exception e)
            {
                return ErrorReturn<List<TEntity>>(e);
            }
        }

        #endregion

        #region Add


        public virtual IReturn<TEntity> Add(TEntity entity)
        {
            try
            {
                entity.InsertedAt = DateTime.Now;
                context.Set<TEntity>().Add(entity);
                return Save(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual IReturn<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entity)
        {
            try
            {
                entity.ChangeAll(e => e.InsertedAt = DateTime.Now);
                context.Set<TEntity>().AddRange(entity);
                return Save(entity);

            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }

        public virtual async Task<IReturn<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                entity.InsertedAt = DateTime.Now;
                await context.Set<TEntity>().AddAsync(entity);
                return await SaveAsync(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TEntity>>> AddAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                entity.ChangeAll(e => e.InsertedAt = DateTime.Now);
                await context.Set<TEntity>().AddRangeAsync(entity);
                return await SaveAsync(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }


        #endregion

        #region Update


        public virtual IReturn<TEntity> Update(TEntity entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.Now;
                context.Set<TEntity>().Update(entity);
                return Save(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual IReturn<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity)
        {
            try
            {
                entity.ChangeAll(e => e.UpdatedAt = DateTime.Now);
                context.Set<TEntity>().UpdateRange(entity);
                return Save(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }

        public virtual async Task<IReturn<TEntity>> UpdateAsync(TEntity entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.Now;
                context.Set<TEntity>().Update(entity);
                return await SaveAsync(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TEntity>>> UpdateAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                entity.ChangeAll(e => e.UpdatedAt = DateTime.Now);
                context.Set<TEntity>().UpdateRange(entity);
                return await SaveAsync(entity);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }


        #endregion


        #region Delete


        public virtual IReturn<TEntity> Delete(TEntity entity)
        {
            try
            {
                TEntity ent = context.Set<TEntity>().AsNoTracking().First(e => e.Id == entity.Id);
                ent.IsDeleted = true;
                ent.DeletedAt = DateTime.Now;
                context.Set<TEntity>().Update(ent);
                return Save(ent);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual IReturn<IEnumerable<TEntity>> Delete(IEnumerable<TEntity> entity)
        {
            try
            {
                List<TEntity> list = new();
                foreach (TEntity ent in entity)
                {
                    list.Add(context.Set<TEntity>().AsNoTracking().First(e => e.Id == ent.Id));
                }
                list.ChangeAll(e => e.IsDeleted = true);
                list.ChangeAll(e => e.DeletedAt = DateTime.Now);
                context.Set<TEntity>().UpdateRange(list);
                return Save(list);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }

        public virtual async Task<IReturn<TEntity>> DeleteAsync(TEntity entity)
        {
            try
            {
                TEntity ent = await context.Set<TEntity>().AsNoTracking().FirstAsync(e => e.Id == entity.Id);
                ent.IsDeleted = true;
                ent.DeletedAt = DateTime.Now;
                context.Set<TEntity>().Update(ent);
                return await SaveAsync(ent);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TEntity>>> DeleteAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                List<TEntity> list = new();
                foreach (TEntity ent in entity)
                {
                    list.Add(await context.Set<TEntity>().AsNoTracking().FirstAsync(e => e.Id == ent.Id));
                }
                list.ChangeAll(e => e.IsDeleted = true);
                list.ChangeAll(e => e.DeletedAt = DateTime.Now);
                context.Set<TEntity>().UpdateRange(list);
                return await SaveAsync(list);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }


        #endregion

        #region Get

        public virtual IReturn<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var result = context.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var result = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }
        public virtual IReturn<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            try
            {

                IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
                if (filter != null) query = query.Where(filter);
                if (reverse) query = query.Reverse();

                IEnumerable<TEntity> result = query.AsEnumerable();

                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }

        }

        public virtual async Task<IReturn<IEnumerable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
                if (filter != null) query = query.Where(filter);
                if (reverse) query = query.Reverse();
                IEnumerable<TEntity> result = await query.ToListAsync();
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }


        public virtual IReturn<TEntity> GetDeleted(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var result = context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().Where(e => e.IsDeleted).FirstOrDefault(filter);
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<TEntity>> GetDeletedAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var result = await context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().Where(e => e.IsDeleted).FirstOrDefaultAsync(filter);
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual IReturn<IEnumerable<TEntity>> GetAllDeleted(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            try
            {

                IQueryable<TEntity> query = context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().Where(e => e.IsDeleted);
                if (filter != null) query = query.Where(filter);
                if (reverse) query = query.Reverse();
                IEnumerable<TEntity> result = query.AsEnumerable();
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TEntity>>> GetAllDeletedAsync(Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            try
            {

                IQueryable<TEntity> query = context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().Where(e => e.IsDeleted);
                if (filter != null) query = query.Where(filter);
                if (reverse) query = query.Reverse();
                IEnumerable<TEntity> result = await query.ToListAsync();
                return CheckIsNull(result);
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }


        #endregion

        #region Count


        public virtual IReturn<int> Count(Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturn<int>(filter == null ? context.Set<TEntity>().AsNoTracking().Count() : context.Set<TEntity>().AsNoTracking().Count(filter));
            }
            catch (Exception e)
            {
                return ErrorReturn<int>(e);
            }
        }

        public virtual async Task<IReturn<int>> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturn<int>(filter == null ? await context.Set<TEntity>().AsNoTracking().CountAsync() : await context.Set<TEntity>().AsNoTracking().CountAsync(filter));
            }
            catch (Exception e)
            {
                return ErrorReturn<int>(e);
            }
        }

        #endregion

        #region IsExist


        public virtual IReturn<bool> IsExist(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                bool res = context.Set<TEntity>().AsNoTracking().Any(filter);
                return new SuccessReturn<bool>(data: res);
            }
            catch (Exception e)
            {
                return ErrorReturn<bool>(e);
            }
        }

        public virtual async Task<IReturn<bool>> IsExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                bool res = await context.Set<TEntity>().AsNoTracking().AnyAsync(filter);
                return new SuccessReturn<bool>(data: res);
            }
            catch (Exception e)
            {
                return ErrorReturn<bool>(e);
            }
        }


        #endregion

        #region Save



        public virtual IReturn<TEntity> Save(TEntity entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturn<TEntity>(entity);
                }
                else
                {
                    return new ErrorReturn<TEntity>(entity);
                }
            }
            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual IReturn<IEnumerable<TEntity>> Save(IEnumerable<TEntity> entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturn<IEnumerable<TEntity>>(entity);
                }
                else
                {
                    return new ErrorReturn<IEnumerable<TEntity>>(entity);
                }
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }

        public virtual async Task<IReturn<TEntity>> SaveAsync(TEntity entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturn<TEntity>(entity);
                }
                else
                {
                    return new ErrorReturn<TEntity>(entity);
                }
            }

            catch (Exception e)
            {
                return ErrorReturn<TEntity>(e);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TEntity>>> SaveAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturn<IEnumerable<TEntity>>(entity);
                }
                else
                {
                    return new ErrorReturn<IEnumerable<TEntity>>(entity);
                }
            }
            catch (Exception e)
            {
                return ErrorReturn<IEnumerable<TEntity>>(e);
            }
        }


        #endregion

        #region Tools

        public virtual IReturn<TNull> CheckIsNull<TNull>(TNull? result)
            => (result == null) ? new NullDataSuccess<TNull>() : new SuccessReturn<TNull>(result, "Data Dolu");



        public virtual IReturn<TNull> ErrorReturn<TNull>(Exception e)
        {
            ErrorReturn<TNull> error = new ErrorReturn<TNull>($"{typeof(TEntity).Name} ile üretilen {nameof(Repository<TEntity>)} sınıfında hata var. Hata mesajı = {e.Message}", e);
            return error;
        }
        public virtual void Dispose()
        {
            context.Dispose();
            if (transaction != null) { CleanupTransaction(); }
        }

        public virtual async ValueTask DisposeAsync()
        {
            if (transaction != null) { await CleanupTransactionAsync(); }
            await context.DisposeAsync();
        }

        public virtual void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }


        public virtual async Task BeginTransactionAsync()
        {
            transaction = await context.Database.BeginTransactionAsync();
        }
        public virtual void Commit()
        {
            if (transaction == null) throw new InvalidOperationException("Transaction başlatılmadı.");
            transaction.Commit();
            CleanupTransaction();
        }
        public virtual async Task CommitAsync()
        {
            if (transaction == null) throw new InvalidOperationException("Transaction başlatılmadı.");
            await transaction.CommitAsync();
            CleanupTransaction();
        }
        public virtual void Rollback()
        {
            if (transaction == null) throw new InvalidOperationException("Transaction başlatılmadı.");
            transaction.Rollback();
            CleanupTransaction();
        }
        public virtual async Task RollbackAsync()
        {
            if (transaction == null) throw new InvalidOperationException("Transaction başlatılmadı.");
            await transaction.RollbackAsync();
            await CleanupTransactionAsync();
        }

        private void CleanupTransaction()
        {
            if (transaction != null) transaction.Dispose();
            transaction = null;
        }
        private async Task CleanupTransactionAsync()
        {
            if (transaction != null) await transaction.DisposeAsync();
            transaction = null;
        }

        #endregion

    }
}
