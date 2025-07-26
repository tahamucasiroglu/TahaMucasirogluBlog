using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Concrete
{
    public class SubSkillDatabaseService : CvDatabaseService<SubSkill, GetSubSkillDTO, AddSubSkillDTO, UpdateSubSkillDTO, DeleteSubSkillDTO>, ISubSkillDatabaseService
    {
        public SubSkillDatabaseService(ISubSkillRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSubSkillDTO> addValidator, IValidator<IEnumerable<AddSubSkillDTO>> addValidatorList, IValidator<UpdateSubSkillDTO> updateValidator, IValidator<IEnumerable<UpdateSubSkillDTO>> updateValidatorList, IValidator<DeleteSubSkillDTO> deleteValidator, IValidator<IEnumerable<DeleteSubSkillDTO>> deleteValidatorList, ILogger<SubSkillDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
