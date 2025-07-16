using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.CvDatabase.Abstract;
using TahaMucasirogluCv.Service.CvDatabase.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Concrete.Cv
{
    public class SkillDatabaseService : CvDatabaseService<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO>, ISkillDatabaseService
    {
        public SkillDatabaseService(ISkillRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSkillDTO> addValidator, IValidator<IEnumerable<AddSkillDTO>> addValidatorList, IValidator<UpdateSkillDTO> updateValidator, IValidator<IEnumerable<UpdateSkillDTO>> updateValidatorList, IValidator<DeleteSkillDTO> deleteValidator, IValidator<IEnumerable<DeleteSkillDTO>> deleteValidatorList, ILogger<SkillDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
