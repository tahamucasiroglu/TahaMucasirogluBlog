using FluentValidation;
using TahaMucasiroglu.Application.Validation.Concrete.Statistic.CvStatistic;
using TahaMucasiroglu.Application.Validation.Concrete.Statistic.P2PMessageStatistic;

namespace TahaMucasiroglu.Presentation.StatisticAPI.Extensions
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


            services.AddValidatorsFromAssemblyContaining<AddCvStatisticDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddCvStatisticListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCvStatisticDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCvStatisticListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCvStatisticDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCvStatisticListDTOValidation>();


        }
    }
}
