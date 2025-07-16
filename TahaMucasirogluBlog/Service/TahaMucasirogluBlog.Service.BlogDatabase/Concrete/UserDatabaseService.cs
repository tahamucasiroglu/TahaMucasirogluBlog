using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.User;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.BlogDatabase.Abstract;
using TahaMucasirogluBlog.Service.BlogDatabase.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete.Blog
{
    public class UserDatabaseService : BlogDatabaseService<User, GetUserDTO, AddUserDTO, UpdateUserDTO, DeleteUserDTO>, IUserDatabaseService
    {
        public UserDatabaseService(IUserRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddUserDTO> addValidator, IValidator<IEnumerable<AddUserDTO>> addValidatorList, IValidator<UpdateUserDTO> updateValidator, IValidator<IEnumerable<UpdateUserDTO>> updateValidatorList, IValidator<DeleteUserDTO> deleteValidator, IValidator<IEnumerable<DeleteUserDTO>> deleteValidatorList, ILogger<UserDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
