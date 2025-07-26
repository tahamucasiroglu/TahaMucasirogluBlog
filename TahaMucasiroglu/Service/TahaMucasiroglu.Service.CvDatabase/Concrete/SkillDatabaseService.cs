using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Concrete
{
    public class SkillDatabaseService : CvDatabaseService<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO>, ISkillDatabaseService
    {
        public SkillDatabaseService(ISkillRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSkillDTO> addValidator, IValidator<IEnumerable<AddSkillDTO>> addValidatorList, IValidator<UpdateSkillDTO> updateValidator, IValidator<IEnumerable<UpdateSkillDTO>> updateValidatorList, IValidator<DeleteSkillDTO> deleteValidator, IValidator<IEnumerable<DeleteSkillDTO>> deleteValidatorList, ILogger<SkillDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
