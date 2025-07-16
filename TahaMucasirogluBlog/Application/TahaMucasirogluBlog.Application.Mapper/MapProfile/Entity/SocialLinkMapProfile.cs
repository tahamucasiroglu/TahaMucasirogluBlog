using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Main.SocialLink;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Main;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
