using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.User;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class UserDatabaseService : DatabaseService<User, GetUserDTO, AddUserDTO, UpdateUserDTO, DeleteUserDTO>, IUserDatabaseService
    {
        public UserDatabaseService(IUserRepository repository, IMapper mapper, IConfiguration configuration, ILogger<UserDatabaseService> logger) : base(repository, mapper, configuration, logger)
        {
        }
    }
}
