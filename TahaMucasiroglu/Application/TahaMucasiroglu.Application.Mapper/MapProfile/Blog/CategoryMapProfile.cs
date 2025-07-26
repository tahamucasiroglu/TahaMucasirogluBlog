using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Category;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
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
