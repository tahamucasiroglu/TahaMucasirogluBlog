using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
{
    public class BlogPostCategoryMapProfile : Profile
    {
        public BlogPostCategoryMapProfile()
        {
            CreateMap<AddBlogPostCategoryDTO, BlogPostCategory>().DefaultAddMapConfig();
            CreateMap<UpdateBlogPostCategoryDTO, BlogPostCategory>().DefaultUpdateMapConfig();
            CreateMap<DeleteBlogPostCategoryDTO, BlogPostCategory>().DefaultDeleteMapConfig();
            CreateMap<BlogPostCategory, GetBlogPostCategoryDTO>();
        }
    }
}
