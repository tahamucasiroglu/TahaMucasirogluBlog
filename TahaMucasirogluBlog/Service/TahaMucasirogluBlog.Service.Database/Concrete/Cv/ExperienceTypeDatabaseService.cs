using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract.Cv;
using TahaMucasirogluBlog.Service.Database.Base;
using TahaMucasirogluCv.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete.Cv
{
    public class ExperienceTypeDatabaseService : CvDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>, IExperienceTypeDatabaseService
    {
        public ExperienceTypeDatabaseService(IExperienceTypeRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceTypeDTO> addValidator, IValidator<IEnumerable<AddExperienceTypeDTO>> addValidatorList, IValidator<UpdateExperienceTypeDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceTypeDTO>> updateValidatorList, IValidator<DeleteExperienceTypeDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceTypeDTO>> deleteValidatorList, ILogger<ExperienceTypeDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
