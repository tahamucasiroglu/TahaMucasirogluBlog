using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Concrete
{
    public class ExperienceTypeDatabaseService : CvDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>, IExperienceTypeDatabaseService
    {
        public ExperienceTypeDatabaseService(IExperienceTypeRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceTypeDTO> addValidator, IValidator<IEnumerable<AddExperienceTypeDTO>> addValidatorList, IValidator<UpdateExperienceTypeDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceTypeDTO>> updateValidatorList, IValidator<DeleteExperienceTypeDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceTypeDTO>> deleteValidatorList, ILogger<ExperienceTypeDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
