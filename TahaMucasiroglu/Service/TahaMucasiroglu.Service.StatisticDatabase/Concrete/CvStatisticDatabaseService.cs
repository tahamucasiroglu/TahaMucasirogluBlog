using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.StatisticRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Base;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract;
using TahaMucasiroglu.Service.StatisticDatabase.Base;

namespace TahaMucasiroglu.Service.StatisticDatabase.Concrete
{
    public class CvStatisticDatabaseService : StatisticDatabaseService<CvStatistic, GetCvStatisticDTO, AddCvStatisticDTO, UpdateCvStatisticDTO, DeleteCvStatisticDTO>, ICvStatisticDatabaseService
    {
        public CvStatisticDatabaseService(
            ICvStatisticRepository repository,
            IMapper mapper,
            IConfiguration configuration,
            IValidator<AddCvStatisticDTO> addValidator,
            IValidator<IEnumerable<AddCvStatisticDTO>> addValidatorList,
            IValidator<UpdateCvStatisticDTO> updateValidator,
            IValidator<IEnumerable<UpdateCvStatisticDTO>> updateValidatorList,
            IValidator<DeleteCvStatisticDTO> deleteValidator,
            IValidator<IEnumerable<DeleteCvStatisticDTO>> deleteValidatorList,
            ILogger<DatabaseService<CvStatistic, GetCvStatisticDTO>> logger)
            : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
