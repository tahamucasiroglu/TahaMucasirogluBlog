using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostCategory;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
