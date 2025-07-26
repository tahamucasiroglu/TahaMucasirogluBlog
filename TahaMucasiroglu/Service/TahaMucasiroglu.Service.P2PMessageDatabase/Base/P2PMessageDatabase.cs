using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Base;
using TahaMucasiroglu.Service.P2PMessageDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.P2PMessageDatabase.Base
{
    public class P2PMessageDatabase<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, IP2PMessageDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
      where TEntity : class, IP2PMessageEntity
      where TResponse : class, IP2PMessageGetDTO
       where TAddRequest : class, IStatisticAddDTO
        where TUpdateRequest : class, IStatisticUpdateDTO
        where TDeleteRequest : class, IStatisticDeleteDTO
    {
        public P2PMessageDatabase(
            IP2PMessageRepository<TEntity> repository,
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
