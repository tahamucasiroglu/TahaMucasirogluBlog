using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract.Statistic;
using TahaMucasiroglu.Domain.DTOs.Base;

namespace TahaMucasiroglu.Domain.DTOs.Bsae.Statistic
{
    public record StatisticDeleteDTO : DeleteDTO, IStatisticDeleteDTO
    {
    }
}
