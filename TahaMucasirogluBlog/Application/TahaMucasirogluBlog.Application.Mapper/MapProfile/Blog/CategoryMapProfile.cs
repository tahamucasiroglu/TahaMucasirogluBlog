using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Category;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<AddCategoryDTO, Category>().DefaultAddMapConfig();
            CreateMap<UpdateCategoryDTO, Category>().DefaultUpdateMapConfig();
            CreateMap<DeleteCategoryDTO, Category>().DefaultDeleteMapConfig();
            CreateMap<Category, GetCategoryDTO>();
        }
    }
}
