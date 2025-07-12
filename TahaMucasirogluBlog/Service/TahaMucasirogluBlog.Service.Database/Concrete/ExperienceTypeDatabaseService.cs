using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class ExperienceTypeDatabaseService : DatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>, IExperienceTypeDatabaseService
    {
        public ExperienceTypeDatabaseService(IExperienceTypeRepository repository, IMapper mapper, IConfiguration configuration, ILogger<ExperienceTypeDatabaseService> logger) : base(repository, mapper, configuration, logger)
        {
        }
    }
}
