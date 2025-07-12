using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class SkillDatabaseService : DatabaseService<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO>, ISkillDatabaseService
    {
        public SkillDatabaseService(ISkillRepository repository, IMapper mapper, IConfiguration configuration, ILogger<SkillDatabaseService> logger) : base(repository, mapper, configuration, logger)
        {
        }
    }
}
