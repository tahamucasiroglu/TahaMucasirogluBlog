using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPost;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
{
    public class BlogPostMapProfile : Profile
    {
        public BlogPostMapProfile()
        {
            CreateMap<AddBlogPostDTO, BlogPost>().DefaultAddMapConfig();
            CreateMap<UpdateBlogPostDTO, BlogPost>().DefaultUpdateMapConfig();
            CreateMap<DeleteBlogPostDTO, BlogPost>().DefaultDeleteMapConfig();
            CreateMap<BlogPost, GetBlogPostDTO>();
        }
    }
}
