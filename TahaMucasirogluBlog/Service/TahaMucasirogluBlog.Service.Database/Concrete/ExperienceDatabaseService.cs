using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class ExperienceDatabaseService : DatabaseService<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>, IExperienceDatabaseService
    {
        public ExperienceDatabaseService(IExperienceRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceDTO> addValidator, IValidator<IEnumerable<AddExperienceDTO>> addValidatorList, IValidator<UpdateExperienceDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceDTO>> updateValidatorList, IValidator<DeleteExperienceDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceDTO>> deleteValidatorList, ILogger<ExperienceDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
