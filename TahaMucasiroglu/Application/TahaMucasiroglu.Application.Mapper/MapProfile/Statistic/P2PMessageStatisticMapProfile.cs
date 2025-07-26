using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.Entities.Concrete.Statistic;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Statistic
{
    public class P2PMessageStatisticMapProfile : Profile
    {
        public P2PMessageStatisticMapProfile()
        {
            CreateMap<AddP2PMessageStatisticDTO, P2PMessageStatistic>().DefaultAddMapConfig();
            CreateMap<UpdateP2PMessageStatisticDTO, P2PMessageStatistic>().DefaultUpdateMapConfig();
            CreateMap<DeleteP2PMessageStatisticDTO, P2PMessageStatistic>().DefaultDeleteMapConfig();
            CreateMap<P2PMessageStatistic, GetP2PMessageStatisticDTO>();
        }
    }
}
