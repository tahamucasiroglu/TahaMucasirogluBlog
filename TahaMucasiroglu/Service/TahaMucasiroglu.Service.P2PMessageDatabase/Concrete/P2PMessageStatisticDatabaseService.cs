using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Infrastructure.P2PMessageRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Base;
using TahaMucasiroglu.Service.P2PMessageDatabase.Abstract;

namespace TahaMucasiroglu.Service.P2PMessageDatabase.Concrete
{
    public class P2PMessageStatisticDatabaseService : DatabaseService<P2PMessageStatistic, GetP2PMessageStatisticDTO, AddP2PMessageStatisticDTO, UpdateP2PMessageStatisticDTO, DeleteP2PMessageStatisticDTO>, IP2PMessageStatisticDatabaseService
    {
        public P2PMessageStatisticDatabaseService(
            IP2PMessageStatisticRepository repository, 
            IMapper mapper, 
            IConfiguration configuration, 
            IValidator<AddP2PMessageStatisticDTO> addValidator, 
            IValidator<IEnumerable<AddP2PMessageStatisticDTO>> addValidatorList, 
            IValidator<UpdateP2PMessageStatisticDTO> updateValidator, 
            IValidator<IEnumerable<UpdateP2PMessageStatisticDTO>> updateValidatorList, 
            IValidator<DeleteP2PMessageStatisticDTO> deleteValidator, 
            IValidator<IEnumerable<DeleteP2PMessageStatisticDTO>> deleteValidatorList, 
            ILogger<DatabaseService<P2PMessageStatistic, GetP2PMessageStatisticDTO>> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
