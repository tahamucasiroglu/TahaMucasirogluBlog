using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.CvDatabase.Abstract;
using TahaMucasirogluCv.Service.CvDatabase.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Concrete
{
    public class ExperienceDatabaseService : CvDatabaseService<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>, IExperienceDatabaseService
    {
        public ExperienceDatabaseService(IExperienceRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceDTO> addValidator, IValidator<IEnumerable<AddExperienceDTO>> addValidatorList, IValidator<UpdateExperienceDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceDTO>> updateValidatorList, IValidator<DeleteExperienceDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceDTO>> deleteValidatorList, ILogger<ExperienceDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
