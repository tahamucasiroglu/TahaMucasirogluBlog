using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostTag;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
{
    public class BlogPostTagMapProfile : Profile
    {
        public BlogPostTagMapProfile()
        {
            CreateMap<AddBlogPostTagDTO, BlogPostTag>().DefaultAddMapConfig();
            CreateMap<UpdateBlogPostTagDTO, BlogPostTag>().DefaultUpdateMapConfig();
            CreateMap<DeleteBlogPostTagDTO, BlogPostTag>().DefaultDeleteMapConfig();
            CreateMap<BlogPostTag, GetBlogPostTagDTO>();
        }
    }
}
