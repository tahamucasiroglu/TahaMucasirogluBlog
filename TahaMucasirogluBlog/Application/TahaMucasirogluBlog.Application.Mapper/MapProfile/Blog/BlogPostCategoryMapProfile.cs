using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog
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
