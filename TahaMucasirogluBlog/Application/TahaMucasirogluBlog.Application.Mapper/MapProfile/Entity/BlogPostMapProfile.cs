using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPost;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
