using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv
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
