using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Category;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Blog;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete.Blog
{
    public class CategoryDatabaseService : BlogDatabaseService<Category, GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO, DeleteCategoryDTO>, ICategoryDatabaseService
    {
        public CategoryDatabaseService(ICategoryRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddCategoryDTO> addValidator, IValidator<IEnumerable<AddCategoryDTO>> addValidatorList, IValidator<UpdateCategoryDTO> updateValidator, IValidator<IEnumerable<UpdateCategoryDTO>> updateValidatorList, IValidator<DeleteCategoryDTO> deleteValidator, IValidator<IEnumerable<DeleteCategoryDTO>> deleteValidatorList, ILogger<CategoryDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
