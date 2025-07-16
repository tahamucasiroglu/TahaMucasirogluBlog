using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.CvDatabase.Abstract;
using TahaMucasirogluCv.Service.CvDatabase.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Concrete.Cv
{
    public class ExperienceTypeDatabaseService : CvDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>, IExperienceTypeDatabaseService
    {
        public ExperienceTypeDatabaseService(IExperienceTypeRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceTypeDTO> addValidator, IValidator<IEnumerable<AddExperienceTypeDTO>> addValidatorList, IValidator<UpdateExperienceTypeDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceTypeDTO>> updateValidatorList, IValidator<DeleteExperienceTypeDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceTypeDTO>> deleteValidatorList, ILogger<ExperienceTypeDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
