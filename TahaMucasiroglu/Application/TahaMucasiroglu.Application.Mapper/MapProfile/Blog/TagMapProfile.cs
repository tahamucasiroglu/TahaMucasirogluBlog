using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Tag;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
{
    public class TagMapProfile : Profile
    {
        public TagMapProfile()
        {
            CreateMap<AddTagDTO, Tag>().DefaultAddMapConfig();
            CreateMap<UpdateTagDTO, Tag>().DefaultUpdateMapConfig();
            CreateMap<DeleteTagDTO, Tag>().DefaultDeleteMapConfig();
            CreateMap<Tag, GetTagDTO>();
        }
    }
}
