using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Abstract.Cv;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Base;
using TahaMucasirogluCv.Service.Database.Abstract.Base;

namespace TahaMucasirogluCv.Service.Database.Base
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
