using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.CvDatabase.Abstract;
using TahaMucasirogluCv.Service.CvDatabase.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Concrete.Cv
{
    public class SubSkillDatabaseService : CvDatabaseService<SubSkill, GetSubSkillDTO, AddSubSkillDTO, UpdateSubSkillDTO, DeleteSubSkillDTO>, ISubSkillDatabaseService
    {
        public SubSkillDatabaseService(ISubSkillRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSubSkillDTO> addValidator, IValidator<IEnumerable<AddSubSkillDTO>> addValidatorList, IValidator<UpdateSubSkillDTO> updateValidator, IValidator<IEnumerable<UpdateSubSkillDTO>> updateValidatorList, IValidator<DeleteSubSkillDTO> deleteValidator, IValidator<IEnumerable<DeleteSubSkillDTO>> deleteValidatorList, ILogger<SubSkillDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
