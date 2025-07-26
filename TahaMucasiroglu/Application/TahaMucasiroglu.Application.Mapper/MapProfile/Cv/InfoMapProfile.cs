using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Cv
{
    public class InfoMapProfile : Profile
    {
        public InfoMapProfile()
        {
            CreateMap<AddInfoDTO, Info>().DefaultAddMapConfig();
            CreateMap<UpdateInfoDTO, Info>().DefaultUpdateMapConfig();
            CreateMap<DeleteInfoDTO, Info>().DefaultDeleteMapConfig();
            CreateMap<Info, GetInfoDTO>();
        }
    }
}
