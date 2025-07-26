using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;
using TahaMucasiroglu.Service.StatisticDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.StatisticDatabase.Abstract
{
    public interface ICvStatisticDatabaseService : IStatisticDatabaseService<CvStatistic, GetCvStatisticDTO, AddCvStatisticDTO, UpdateCvStatisticDTO, DeleteCvStatisticDTO>
    {
    }
}
