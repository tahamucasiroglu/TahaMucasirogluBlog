using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.CvDatabase.Abstract;
using TahaMucasirogluCv.Service.CvDatabase.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Concrete.Cv
{
    public class InfoDatabaseService : CvDatabaseService<Info, GetInfoDTO, AddInfoDTO, UpdateInfoDTO, DeleteInfoDTO>, IInfoDatabaseService
    {
        public InfoDatabaseService(IInfoRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddInfoDTO> addValidator, IValidator<IEnumerable<AddInfoDTO>> addValidatorList, IValidator<UpdateInfoDTO> updateValidator, IValidator<IEnumerable<UpdateInfoDTO>> updateValidatorList, IValidator<DeleteInfoDTO> deleteValidator, IValidator<IEnumerable<DeleteInfoDTO>> deleteValidatorList, ILogger<InfoDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
