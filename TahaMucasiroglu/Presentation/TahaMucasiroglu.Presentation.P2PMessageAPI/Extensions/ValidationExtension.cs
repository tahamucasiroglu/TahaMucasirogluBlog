using FluentValidation;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.Experience;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceTechnology;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.Info;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.Skill;
using TahaMucasiroglu.Application.Validation.Concrete.Cv.SubSkill;
using TahaMucasiroglu.Application.Validation.Concrete.Statistic.P2PMessageStatistic;

namespace TahaMucasiroglu.Presentation.P2PMessageAPI.Extensions
{
    static public class ValidationExtension
    {
        public static void AddFluentValidationValidators(this IServiceCollection services)
        {


            services.AddValidatorsFromAssemblyContaining<AddP2PMessageStatisticDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddP2PMessageStatisticListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateP2PMessageStatisticDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateP2PMessageStatisticListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteP2PMessageStatisticDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteP2PMessageStatisticListDTOValidation>();


        }
    }
}
