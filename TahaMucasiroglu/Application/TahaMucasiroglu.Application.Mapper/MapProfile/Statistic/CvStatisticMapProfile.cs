

using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Statistic
{
    public class CvStatisticMapProfile : Profile
    {
        public CvStatisticMapProfile()
        {
            CreateMap<AddCvStatisticDTO, CvStatistic>().DefaultAddMapConfig();
            CreateMap<UpdateCvStatisticDTO, CvStatistic>().DefaultUpdateMapConfig();
            CreateMap<DeleteCvStatisticDTO, CvStatistic>().DefaultDeleteMapConfig();
            CreateMap<CvStatistic, GetCvStatisticDTO>();
        }
    }
}
