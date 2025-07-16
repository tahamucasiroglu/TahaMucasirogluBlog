using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPost;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog
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
