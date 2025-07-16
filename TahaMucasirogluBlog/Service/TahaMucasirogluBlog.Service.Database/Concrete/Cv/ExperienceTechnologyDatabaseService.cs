using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract.Cv;
using TahaMucasirogluBlog.Service.Database.Base;
using TahaMucasirogluCv.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete.Cv
{
    public class ExperienceTechnologyDatabaseService : CvDatabaseService<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>, IExperienceTechnologyDatabaseService
    {
        public ExperienceTechnologyDatabaseService(IExperienceTechnologyRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddExperienceTechnologyDTO> addValidator, IValidator<IEnumerable<AddExperienceTechnologyDTO>> addValidatorList, IValidator<UpdateExperienceTechnologyDTO> updateValidator, IValidator<IEnumerable<UpdateExperienceTechnologyDTO>> updateValidatorList, IValidator<DeleteExperienceTechnologyDTO> deleteValidator, IValidator<IEnumerable<DeleteExperienceTechnologyDTO>> deleteValidatorList, ILogger<ExperienceTechnologyDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
