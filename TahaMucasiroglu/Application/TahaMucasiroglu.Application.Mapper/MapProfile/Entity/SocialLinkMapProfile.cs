using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink;
using TahaMucasiroglu.Domain.Entities.Concrete.Main;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Entity
{
    public class SocialLinkMapProfile : Profile
    {
        public SocialLinkMapProfile()
        {
            CreateMap<AddSocialLinkDTO, SocialLink>().DefaultAddMapConfig();
            CreateMap<UpdateSocialLinkDTO, SocialLink>().DefaultUpdateMapConfig();
            CreateMap<DeleteSocialLinkDTO, SocialLink>().DefaultDeleteMapConfig();
            CreateMap<SocialLink, GetSocialLinkDTO>();
        }
    }
}
