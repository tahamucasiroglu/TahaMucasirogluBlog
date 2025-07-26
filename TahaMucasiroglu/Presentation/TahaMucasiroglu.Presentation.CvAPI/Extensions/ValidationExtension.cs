using FluentValidation;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.Experience;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceTechnology;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.Info;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.Skill;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.SubSkill;

namespace TahaMucasiroglu.Presentation.CvAPI.Extensions
{
    static public class ValidationExtension
    {
        public static void AddFluentValidationValidators(this IServiceCollection services)
        {


            services.AddValidatorsFromAssemblyContaining<AddExperienceDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddExperienceListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddExperienceTechnologyDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddExperienceTechnologyListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTechnologyDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTechnologyListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTechnologyDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTechnologyListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddExperienceTypeDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddExperienceTypeListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTypeDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTypeListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTypeDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTypeListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddInfoDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddInfoListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateInfoDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateInfoListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteInfoDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteInfoListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSkillListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddSubSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddSubSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSubSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSubSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSubSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSubSkillListDTOValidation>();


        }
    }
}
