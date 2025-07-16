using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
