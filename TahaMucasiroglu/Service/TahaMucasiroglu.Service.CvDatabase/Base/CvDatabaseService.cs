using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Base;
using TahaMucasiroglu.Service.CvDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Base
{







    public abstract class CvDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, ICvDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
      where TEntity : class, ICvEntity
      where TResponse : class, ICvGetDTO
       where TAddRequest : class, ICvAddDTO
        where TUpdateRequest : class, ICvUpdateDTO
        where TDeleteRequest : class, ICvDeleteDTO
    {
        public CvDatabaseService(
            ICvRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            IValidator<TAddRequest> addValidator,
            IValidator<IEnumerable<TAddRequest>> addValidatorList,
            IValidator<TUpdateRequest> updateValidator,
            IValidator<IEnumerable<TUpdateRequest>> updateValidatorList,
            IValidator<TDeleteRequest> deleteValidator,
            IValidator<IEnumerable<TDeleteRequest>> deleteValidatorList,
            ILogger<DatabaseService<TEntity, TResponse>> logger) :
            base(
                repository,
                mapper,
                configuration,
                addValidator,
                addValidatorList,
                updateValidator,
                updateValidatorList,
                deleteValidator,
                deleteValidatorList,
                logger)
        {
        }

    }
}
