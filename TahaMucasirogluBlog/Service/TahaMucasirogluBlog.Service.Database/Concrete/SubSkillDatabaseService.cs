using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class SubSkillDatabaseService : DatabaseService<SubSkill, GetSubSkillDTO, AddSubSkillDTO, UpdateSubSkillDTO, DeleteSubSkillDTO>, ISubSkillDatabaseService
    {
        public SubSkillDatabaseService(ISubSkillRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSubSkillDTO> addValidator, IValidator<IEnumerable<AddSubSkillDTO>> addValidatorList, IValidator<UpdateSubSkillDTO> updateValidator, IValidator<IEnumerable<UpdateSubSkillDTO>> updateValidatorList, IValidator<DeleteSubSkillDTO> deleteValidator, IValidator<IEnumerable<DeleteSubSkillDTO>> deleteValidatorList, ILogger<SubSkillDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
