using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.User;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Base;

namespace TahaMucasiroglu.Service.Database.Concrete.Blog
{
    public class UserDatabaseService : BlogDatabaseService<User, GetUserDTO, AddUserDTO, UpdateUserDTO, DeleteUserDTO>, IUserDatabaseService
    {
        public UserDatabaseService(IUserRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddUserDTO> addValidator, IValidator<IEnumerable<AddUserDTO>> addValidatorList, IValidator<UpdateUserDTO> updateValidator, IValidator<IEnumerable<UpdateUserDTO>> updateValidatorList, IValidator<DeleteUserDTO> deleteValidator, IValidator<IEnumerable<DeleteUserDTO>> deleteValidatorList, ILogger<UserDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
