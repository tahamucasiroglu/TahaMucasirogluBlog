using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract.Statistic;

namespace TahaMucasiroglu.Application.Validation.Base.Statistic
{
    public class StatisticUpdateValidation<T> : UpdateValidation<T>
        where T : class, IStatisticUpdateDTO
    {
        public StatisticUpdateValidation() : base()
        {
            
        }
    }
}
