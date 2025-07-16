using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Category;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
