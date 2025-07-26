using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Abstract.Statistic;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Base;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.StatisticDatabase.Base
{

    public abstract class StatisticDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, IStatisticDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
      where TEntity : class, IStatisticEntity
      where TResponse : class, IStatisticGetDTO
       where TAddRequest : class, IStatisticAddDTO
        where TUpdateRequest : class, IStatisticUpdateDTO
        where TDeleteRequest : class, IStatisticDeleteDTO
    {
        public StatisticDatabaseService(
            IStatisticRepository<TEntity> repository,
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
