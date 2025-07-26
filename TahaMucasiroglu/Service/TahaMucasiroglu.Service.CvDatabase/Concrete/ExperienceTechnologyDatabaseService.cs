using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Concrete
{
    public class ExperienceTechnologyDatabaseService : CvDatabaseService<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>, IExperienceTechnologyDatabaseService
    {
        public ExperienceTechnologyDatabaseService(IExperienceTechnologyRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceTechnologyDTO> addValidator, IValidator<IEnumerable<AddExperienceTechnologyDTO>> addValidatorList, IValidator<UpdateExperienceTechnologyDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceTechnologyDTO>> updateValidatorList, IValidator<DeleteExperienceTechnologyDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceTechnologyDTO>> deleteValidatorList, ILogger<ExperienceTechnologyDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
