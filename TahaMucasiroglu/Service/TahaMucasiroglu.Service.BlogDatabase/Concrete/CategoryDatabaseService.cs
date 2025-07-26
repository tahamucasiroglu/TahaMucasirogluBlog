using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Category;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Concrete.Blog
{
    public class CategoryDatabaseService : BlogDatabaseService<Category, GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO, DeleteCategoryDTO>, ICategoryDatabaseService
    {
        public CategoryDatabaseService(ICategoryRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddCategoryDTO> addValidator, IValidator<IEnumerable<AddCategoryDTO>> addValidatorList, IValidator<UpdateCategoryDTO> updateValidator, IValidator<IEnumerable<UpdateCategoryDTO>> updateValidatorList, IValidator<DeleteCategoryDTO> deleteValidator, IValidator<IEnumerable<DeleteCategoryDTO>> deleteValidatorList, ILogger<CategoryDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
