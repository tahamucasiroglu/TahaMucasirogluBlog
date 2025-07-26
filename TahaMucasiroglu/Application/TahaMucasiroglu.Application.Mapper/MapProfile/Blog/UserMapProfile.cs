using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.User;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
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
