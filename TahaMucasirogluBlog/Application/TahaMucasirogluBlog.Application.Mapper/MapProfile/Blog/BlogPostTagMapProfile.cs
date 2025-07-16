using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostTag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog
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
