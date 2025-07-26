using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Statistic;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic;

namespace TahaMucasiroglu.Application.Validation.Concrete.Statistic.CvStatistic
{
    public class DeleteCvStatisticListDTOValidation : AbstractValidator<IEnumerable<DeleteCvStatisticDTO>>
    {
        public DeleteCvStatisticListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteCvStatisticDTOValidation());
        }
    }
    public class DeleteCvStatisticDTOValidation : StatisticDeleteValidation<DeleteCvStatisticDTO>
    {
        public DeleteCvStatisticDTOValidation() : base()
        {
            
        }
    }
}
