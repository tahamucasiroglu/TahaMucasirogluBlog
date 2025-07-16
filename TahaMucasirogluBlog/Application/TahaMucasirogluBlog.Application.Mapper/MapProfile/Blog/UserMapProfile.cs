using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.User;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<AddUserDTO, User>().DefaultAddMapConfig();
            CreateMap<UpdateUserDTO, User>().DefaultUpdateMapConfig();
            CreateMap<DeleteUserDTO, User>().DefaultDeleteMapConfig();
            CreateMap<User, GetUserDTO>();
        }
    }
}
