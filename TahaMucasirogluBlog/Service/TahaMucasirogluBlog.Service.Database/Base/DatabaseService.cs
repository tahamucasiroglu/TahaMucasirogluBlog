using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Domain.Return.Abstract;
using TahaMucasirogluBlog.Domain.Return.Concrete;
using TahaMucasirogluBlog.Domain.Return.Constant;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Base
{

    public abstract class DatabaseService<TEntity>
      where TEntity : class, IEntity
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly IMapper mapper;
        internal readonly IConfiguration configuration;
        internal readonly ILogger logger;
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }

        public IReturn<Tout> AutoReturn<Tout, Tin>(IReturn<Tin> model, string message = "", string logMessage = "", bool log = true)
        {
            try
            {
                if(model.Status && model.Data != null)
                {
                    new SuccessReturn<Tout>(message: message, data: mapper.Map<Tout>(model.Data));
                }
                else if(model.Status && model.Data == null)
                {
                    new SuccessReturn<Tout>(message: message);
                }
                else if(!model.Status)
                {

                }

            }
            catch(Exception e)
            {

            }
    
        }





    }



    public abstract class DatabaseService<TEntity, TResponse> : IDatabaseService<TEntity, TResponse>
       where TEntity : class, IEntity
       where TResponse : class, IGetDTO
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly IMapper mapper;
        internal readonly IConfiguration configuration;
        internal readonly ILogger<DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>> logger;
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            ILogger<DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }


    }

        public abstract class DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
       where TEntity : class, IEntity
       where TResponse : class, IGetDTO
       where TAddRequest : class, IAddDTO
       where TUpdateRequest : class, IUpdateDTO
       where TDeleteRequest : class, IDeleteDTO
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly IMapper mapper;
        internal readonly IConfiguration configuration;
        internal readonly ILogger<DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>> logger;
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            ILogger<DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }



        public virtual IReturn<TResponse> Add(TAddRequest entity)
        {
            TEntity ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<TEntity> res = repository.Add(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<TResponse>(message: "Eklemede hata var", res.Exception);
            }
        }

        public virtual IReturn<IEnumerable<TResponse>> Add(IEnumerable<TAddRequest> entity)
        {
            IEnumerable<TEntity> ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<IEnumerable<TEntity>> res = repository.Add(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<IEnumerable<TResponse>>(message: "Eklemede hata var", res.Exception);
            }
        }

        public virtual async Task<IReturn<TResponse>> AddAsync(TAddRequest entity)
        {
            TEntity ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<TEntity> res = await repository.AddAsync(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<TResponse>(message: "Eklemede hata var", res.Exception);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> AddAsync(IEnumerable<TAddRequest> entity)
        {
            IEnumerable<TEntity> ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<IEnumerable<TEntity>> res = await repository.AddAsync(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<IEnumerable<TResponse>>(message: "Eklemede hata var", res.Exception);
            }
        }

        public virtual IReturn<int> Count(MainIdRequest model, Expression<Func<TEntity, bool>>? filter = null)
        {
            return repository.Count(filter);
        }

        public virtual async Task<IReturn<int>> CountAsync(MainIdRequest model, Expression<Func<TEntity, bool>>? filter = null)
        {
            return await repository.CountAsync(filter);
        }

        public virtual IReturn<TResponse> Delete(TDeleteRequest entity)
        {
            IReturn<TEntity> res = repository.Delete(mapper.Map<TEntity>(entity));
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<TResponse>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual IReturn<IEnumerable<TResponse>> Delete(IEnumerable<TDeleteRequest> entity)
        {
            IReturn<IEnumerable<TEntity>> res = repository.Delete(mapper.Map<IEnumerable<TEntity>>(entity));
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<IEnumerable<TResponse>>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual async Task<IReturn<TResponse>> DeleteAsync(TDeleteRequest entity)
        {
            IReturn<TEntity> res = await repository.DeleteAsync(mapper.Map<TEntity>(entity));
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<TResponse>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> DeleteAsync(IEnumerable<TDeleteRequest> entity)
        {
            IReturn<IEnumerable<TEntity>> res = await repository.DeleteAsync(mapper.Map<IEnumerable<TEntity>>(entity));
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<IEnumerable<TResponse>>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }

        public virtual async ValueTask DisposeAsync()
        {
            await repository.DisposeAsync();
        }

        public virtual IReturn<TResponse> Get(MainIdRequest model, Expression<Func<TEntity, bool>> filter)
        {
            IReturn<TEntity> res = repository.Get(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<TResponse>(res);
            }
        }

        public virtual IReturn<IEnumerable<TResponse>> GetAll(MainIdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            IReturn<IEnumerable<TEntity>> res = repository.GetAll(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<IEnumerable<TResponse>>(res);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> GetAllAsync(MainIdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            IReturn<IEnumerable<TEntity>> res = await repository.GetAllAsync(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<IEnumerable<TResponse>>(res);
            }
        }

        public virtual IReturn<IEnumerable<TResponse>> GetAllDeleted(MainIdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            IReturn<IEnumerable<TEntity>> res = repository.GetAllDeleted(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<IEnumerable<TResponse>>(res);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> GetAllDeletedAsync(MainIdRequest model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            IReturn<IEnumerable<TEntity>> res = await repository.GetAllDeletedAsync(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<IEnumerable<TResponse>>(res);
            }
        }

        public virtual async Task<IReturn<TResponse>> GetAsync(MainIdRequest model, Expression<Func<TEntity, bool>> filter)
        {
            IReturn<TEntity> res = await repository.GetAsync(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<TResponse>(res);
            }
        }

        public virtual IReturn<TResponse> GetDeleted(MainIdRequest model, Expression<Func<TEntity, bool>> filter)
        {
            IReturn<TEntity> res = repository.GetDeleted(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<TResponse>(res);
            }
        }

        public virtual async Task<IReturn<TResponse>> GetDeletedAsync(MainIdRequest model, Expression<Func<TEntity, bool>> filter)
        {
            IReturn<TEntity> res = await repository.GetDeletedAsync(filter);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new NullDataError<TResponse>(res);
            }
        }

        public virtual IReturn<bool> IsExist(MainIdRequest model, Expression<Func<TEntity, bool>> filter)
        {
            return repository.IsExist(filter);
        }

        public virtual async Task<IReturn<bool>> IsExistAsync(MainIdRequest model, Expression<Func<TEntity, bool>> filter)
        {
            return await repository.IsExistAsync(filter);
        }

        public virtual IReturn<TResponse> Update(TUpdateRequest entity)
        {
            TEntity ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<TEntity> res = repository.Update(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<TResponse>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual IReturn<IEnumerable<TResponse>> Update(IEnumerable<TUpdateRequest> entity)
        {
            IEnumerable<TEntity> ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<IEnumerable<TEntity>> res = repository.Update(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<IEnumerable<TResponse>>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual async Task<IReturn<TResponse>> UpdateAsync(TUpdateRequest entity)
        {
            TEntity ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<TEntity> res = await repository.UpdateAsync(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<TResponse>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<TResponse>(message: "silmede hata var", res.Exception);
            }
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> UpdateAsync(IEnumerable<TUpdateRequest> entity)
        {
            IEnumerable<TEntity> ent = entity.ConvertToEntityCustom<TEntity>(mapper);
            IReturn<IEnumerable<TEntity>> res = await repository.UpdateAsync(ent);
            if (res.Status && res.Data != null)
            {
                return new SuccessReturn<IEnumerable<TResponse>>(data: res.Data.ConvertToDtoCustom<TResponse>(mapper));
            }
            else
            {
                return new ErrorReturn<IEnumerable<TResponse>>(message: "silmede hata var", res.Exception);
            }
        }


    }
}
