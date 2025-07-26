using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Concrete
{
    public class InfoDatabaseService : CvDatabaseService<Info, GetInfoDTO, AddInfoDTO, UpdateInfoDTO, DeleteInfoDTO>, IInfoDatabaseService
    {
        public InfoDatabaseService(IInfoRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddInfoDTO> addValidator, IValidator<IEnumerable<AddInfoDTO>> addValidatorList, IValidator<UpdateInfoDTO> updateValidator, IValidator<IEnumerable<UpdateInfoDTO>> updateValidatorList, IValidator<DeleteInfoDTO> deleteValidator, IValidator<IEnumerable<DeleteInfoDTO>> deleteValidatorList, ILogger<InfoDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
