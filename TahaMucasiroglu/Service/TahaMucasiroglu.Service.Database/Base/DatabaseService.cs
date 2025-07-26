using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TahaMucasiroglu.Domain.DTOs.Abstract;
using TahaMucasiroglu.Domain.DTOs.Concrete.Request;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Domain.Extensions;
using TahaMucasiroglu.Domain.Return.Abstract;
using TahaMucasiroglu.Domain.Return.Concrete;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.Database.Base
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

        public ErrorReturn<T> ValidationReturn<T>(ValidationResult validationResult)
            => new ErrorReturn<T>(message: string.Join("", validationResult.Errors.Select(e => $"{e.PropertyName} - {e.ErrorMessage}\n")));



        public IReturn<Tout> AutoReturn<Tout, Tin>(IReturn<Tin> model, string message = "", string errorMessage = "", bool log = true)
        {
            try
            {
                if (model.Status && model.Data != null)
                {
                    return new SuccessReturn<Tout>(message: message, data: mapper.Map<Tout>(model.Data));
                }
                else if (model.Status && model.Data == null)
                {
                    return new SuccessReturn<Tout>(message: message);
                }
                else //if(!model.Status)
                {
                    logger.LogError(model.Exception, $"Serivce AutoReturn Hata. \nKullanıcı Hata Mesajı = {errorMessage}\nGelen Hata Mesajı = {model.Message}\nHata = {model.Exception?.Message}");
                    return new ErrorReturn<Tout>(message: errorMessage);
                }

            }
            catch (Exception e)
            {
                logger.LogError(e, $"Serivce AutoReturn Hata. \nKullanıcı Hata Mesajı = {errorMessage}\nGelen Hata Mesajı = {model.Message}\nHata = {model.Exception?.Message}\nException Hatası = {e.Message}");
                return new ErrorReturn<Tout>();
            }

        }





    }

    public abstract class DatabaseService<TEntity, TResponse> : DatabaseService<TEntity>, IDatabaseService<TEntity, TResponse>
       where TEntity : class, IEntity
       where TResponse : class, IGetDTO
    {
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            ILogger<DatabaseService<TEntity, TResponse>> logger) : base(repository, mapper, configuration, logger) { }


        public virtual IReturn<int> Count(IdRequestDTO model, Expression<Func<TEntity, bool>>? filter = null)
        {
            return repository.Count(filter);
        }

        public virtual async Task<IReturn<int>> CountAsync(IdRequestDTO model, Expression<Func<TEntity, bool>>? filter = null)
        {
            return await repository.CountAsync(filter);
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }

        public virtual async ValueTask DisposeAsync()
        {
            await repository.DisposeAsync();
        }

        public virtual IReturn<TResponse> Get(IdRequestDTO model, Expression<Func<TEntity, bool>> filter)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile Get Sorgusu yaptı.");
            return AutoReturn<TResponse, TEntity>(repository.Get(filter));
        }

        public virtual IReturn<IEnumerable<TResponse>> GetAll(IdRequestDTO model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetAll Sorgusu yaptı.");
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(repository.GetAll(filter));
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> GetAllAsync(IdRequestDTO model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetAllAsync Sorgusu yaptı.");
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(await repository.GetAllAsync(filter));
        }

        public virtual IReturn<IEnumerable<TResponse>> GetAllDeleted(IdRequestDTO model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetAllDeleted Sorgusu yaptı.");
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(repository.GetAllDeleted(filter));
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> GetAllDeletedAsync(IdRequestDTO model, Expression<Func<TEntity, bool>>? filter = null, bool reverse = false)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetAllDeletedAsync Sorgusu yaptı.");
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(await repository.GetAllDeletedAsync(filter));
        }

        public virtual async Task<IReturn<TResponse>> GetAsync(IdRequestDTO model, Expression<Func<TEntity, bool>> filter)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetAsync Sorgusu yaptı.");
            return AutoReturn<TResponse, TEntity>(await repository.GetAsync(filter));
        }

        public virtual IReturn<TResponse> GetDeleted(IdRequestDTO model, Expression<Func<TEntity, bool>> filter)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetDeleted Sorgusu yaptı.");
            return AutoReturn<TResponse, TEntity>(repository.GetDeleted(filter));
        }

        public virtual async Task<IReturn<TResponse>> GetDeletedAsync(IdRequestDTO model, Expression<Func<TEntity, bool>> filter)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile GetDeletedAsync Sorgusu yaptı.");
            return AutoReturn<TResponse, TEntity>(await repository.GetDeletedAsync(filter));
        }

        public virtual IReturn<bool> IsExist(IdRequestDTO model, Expression<Func<TEntity, bool>> filter)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile IsExist Sorgusu yaptı.");
            return repository.IsExist(filter);
        }

        public virtual async Task<IReturn<bool>> IsExistAsync(IdRequestDTO model, Expression<Func<TEntity, bool>> filter)
        {
            logger.LogInformation($"{model.IslemYapanKullaniciId} idli kullanıcı, {model.Id} değeri ile birlikte, \n {filter.ToJson()} \n filtresi ile IsExistAsync Sorgusu yaptı.");
            return await repository.IsExistAsync(filter);
        }

    }


    public abstract class DatabaseService<TEntity, TResponse, TAddRequest> : DatabaseService<TEntity, TResponse>, IDatabaseService<TEntity, TResponse, TAddRequest>
       where TEntity : class, IEntity
       where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
    {
        internal readonly IValidator<TAddRequest> addValidator;
        internal readonly IValidator<IEnumerable<TAddRequest>> addValidatorList;
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            IValidator<TAddRequest> addValidator,
            IValidator<IEnumerable<TAddRequest>> addValidatorList,
            ILogger<DatabaseService<TEntity, TResponse>> logger) : base(repository, mapper, configuration, logger)
        {
            this.addValidator = addValidator;
            this.addValidatorList = addValidatorList;
        }


        public virtual IReturn<TResponse> Add(TAddRequest entity)
        {
            ValidationResult addValidationResult = addValidator.Validate(entity);
            if (!addValidationResult.IsValid) return ValidationReturn<TResponse>(addValidationResult);
            TEntity ent = mapper.Map<TEntity>(entity);
            return AutoReturn<TResponse, TEntity>(repository.Add(ent));
        }

        public virtual IReturn<IEnumerable<TResponse>> Add(IEnumerable<TAddRequest> entity)
        {
            ValidationResult addValidationResult = addValidatorList.Validate(entity);
            if (!addValidationResult.IsValid) return ValidationReturn<IEnumerable<TResponse>>(addValidationResult);
            IEnumerable<TEntity> ent = mapper.Map<IEnumerable<TEntity>>(entity);
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(repository.Add(ent));
        }

        public virtual async Task<IReturn<TResponse>> AddAsync(TAddRequest entity)
        {
            ValidationResult addValidationResult = await addValidator.ValidateAsync(entity);
            if (!addValidationResult.IsValid) return ValidationReturn<TResponse>(addValidationResult);
            TEntity ent = mapper.Map<TEntity>(entity);
            return AutoReturn<TResponse, TEntity>(await repository.AddAsync(ent));
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> AddAsync(IEnumerable<TAddRequest> entity)
        {

            ValidationResult addValidationResult = await addValidatorList.ValidateAsync(entity);
            if (!addValidationResult.IsValid) return ValidationReturn<IEnumerable<TResponse>>(addValidationResult);
            IEnumerable<TEntity> ent = mapper.Map<IEnumerable<TEntity>>(entity);
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(await repository.AddAsync(ent));
        }

    }

    public abstract class DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest> : DatabaseService<TEntity, TResponse, TAddRequest>, IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest>
      where TEntity : class, IEntity
      where TResponse : class, IGetDTO
       where TAddRequest : class, IAddDTO
        where TUpdateRequest : class, IUpdateDTO
    {
        internal readonly IValidator<TUpdateRequest> updateValidator;
        internal readonly IValidator<IEnumerable<TUpdateRequest>> updateValidatorList;
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            IValidator<TAddRequest> addValidator,
            IValidator<IEnumerable<TAddRequest>> addValidatorList,
            IValidator<TUpdateRequest> updateValidator,
            IValidator<IEnumerable<TUpdateRequest>> updateValidatorList,
            ILogger<DatabaseService<TEntity, TResponse>> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, logger)
        {
            this.updateValidator = updateValidator;
            this.updateValidatorList = updateValidatorList;
        }



        public virtual IReturn<TResponse> Update(TUpdateRequest entity)
        {
            ValidationResult updateValidationResult = updateValidator.Validate(entity);
            if (!updateValidationResult.IsValid) return ValidationReturn<TResponse>(updateValidationResult);
            TEntity ent = mapper.Map<TEntity>(entity);
            return AutoReturn<TResponse, TEntity>(repository.Update(ent));
        }

        public virtual IReturn<IEnumerable<TResponse>> Update(IEnumerable<TUpdateRequest> entity)
        {
            ValidationResult updateValidationResult = updateValidatorList.Validate(entity);
            if (!updateValidationResult.IsValid) return ValidationReturn<IEnumerable<TResponse>>(updateValidationResult);
            IEnumerable<TEntity> ent = mapper.Map<IEnumerable<TEntity>>(entity);
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(repository.Update(ent));
        }

        public virtual async Task<IReturn<TResponse>> UpdateAsync(TUpdateRequest entity)
        {
            ValidationResult updateValidationResult = await updateValidator.ValidateAsync(entity);
            if (!updateValidationResult.IsValid) return ValidationReturn<TResponse>(updateValidationResult);
            TEntity ent = mapper.Map<TEntity>(entity);
            return AutoReturn<TResponse, TEntity>(await repository.UpdateAsync(ent));
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> UpdateAsync(IEnumerable<TUpdateRequest> entity)
        {
            ValidationResult updateValidationResult = await updateValidatorList.ValidateAsync(entity);
            if (!updateValidationResult.IsValid) return ValidationReturn<IEnumerable<TResponse>>(updateValidationResult);
            IEnumerable<TEntity> ent = mapper.Map<IEnumerable<TEntity>>(entity);
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(await repository.UpdateAsync(ent));
        }

    }


    public abstract class DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest>, IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
      where TEntity : class, IEntity
      where TResponse : class, IGetDTO
       where TAddRequest : class, IAddDTO
        where TUpdateRequest : class, IUpdateDTO
        where TDeleteRequest : class, IDeleteDTO
    {
        private readonly IValidator<TDeleteRequest> deleteValidator;
        private readonly IValidator<IEnumerable<TDeleteRequest>> deleteValidatorList;
        public DatabaseService(
            IRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            IValidator<TAddRequest> addValidator,
            IValidator<IEnumerable<TAddRequest>> addValidatorList,
            IValidator<TUpdateRequest> updateValidator,
            IValidator<IEnumerable<TUpdateRequest>> updateValidatorList,
            IValidator<TDeleteRequest> deleteValidator,
            IValidator<IEnumerable<TDeleteRequest>> deleteValidatorList,
            ILogger<DatabaseService<TEntity, TResponse>> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, logger)
        {
            this.deleteValidator = deleteValidator;
            this.deleteValidatorList = deleteValidatorList;
        }

        public virtual IReturn<TResponse> Delete(TDeleteRequest entity)
        {
            ValidationResult deleteValidationResult = deleteValidator.Validate(entity);
            if (!deleteValidationResult.IsValid) return ValidationReturn<TResponse>(deleteValidationResult);
            return AutoReturn<TResponse, TEntity>(repository.Delete(mapper.Map<TEntity>(entity)));
        }

        public virtual IReturn<IEnumerable<TResponse>> Delete(IEnumerable<TDeleteRequest> entity)
        {
            ValidationResult deleteValidationResult = deleteValidatorList.Validate(entity);
            if (!deleteValidationResult.IsValid) return ValidationReturn<IEnumerable<TResponse>>(deleteValidationResult);
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(repository.Delete(mapper.Map<IEnumerable<TEntity>>(entity)));
        }

        public virtual async Task<IReturn<TResponse>> DeleteAsync(TDeleteRequest entity)
        {
            ValidationResult deleteValidationResult = await deleteValidator.ValidateAsync(entity);
            if (!deleteValidationResult.IsValid) return ValidationReturn<TResponse>(deleteValidationResult);
            return AutoReturn<TResponse, TEntity>(await repository.DeleteAsync(mapper.Map<TEntity>(entity)));
        }

        public virtual async Task<IReturn<IEnumerable<TResponse>>> DeleteAsync(IEnumerable<TDeleteRequest> entity)
        {
            ValidationResult deleteValidationResult = await deleteValidatorList.ValidateAsync(entity);
            if (!deleteValidationResult.IsValid) return ValidationReturn<IEnumerable<TResponse>>(deleteValidationResult);
            return AutoReturn<IEnumerable<TResponse>, IEnumerable<TEntity>>(await repository.DeleteAsync(mapper.Map<IEnumerable<TEntity>>(entity)));
        }
    }


}
