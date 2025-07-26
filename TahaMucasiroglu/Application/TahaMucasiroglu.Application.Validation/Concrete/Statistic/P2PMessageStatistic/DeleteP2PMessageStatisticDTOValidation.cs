using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base.Statistic;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;

namespace TahaMucasiroglu.Application.Validation.Concrete.Statistic.P2PMessageStatistic
{
    public class DeleteP2PMessageStatisticListDTOValidation : AbstractValidator<IEnumerable<DeleteP2PMessageStatisticDTO>>
    {
        public DeleteP2PMessageStatisticListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteP2PMessageStatisticDTOValidation());
        }
    }
    public class DeleteP2PMessageStatisticDTOValidation : StatisticDeleteValidation<DeleteP2PMessageStatisticDTO>
    {
        public DeleteP2PMessageStatisticDTOValidation() : base()
        {
            
        }
    }
}
