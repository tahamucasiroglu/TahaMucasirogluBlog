using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostCategory;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class BlogPostCategoryDatabaseService : DatabaseService<BlogPostCategory, GetBlogPostCategoryDTO, AddBlogPostCategoryDTO, UpdateBlogPostCategoryDTO, DeleteBlogPostCategoryDTO>, IBlogPostCategoryDatabaseService
    {
        public BlogPostCategoryDatabaseService(IBlogPostCategoryRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddBlogPostCategoryDTO> addValidator, IValidator<IEnumerable<AddBlogPostCategoryDTO>> addValidatorList, IValidator<UpdateBlogPostCategoryDTO> updateValidator, IValidator<IEnumerable<UpdateBlogPostCategoryDTO>> updateValidatorList, IValidator<DeleteBlogPostCategoryDTO> deleteValidator, IValidator<IEnumerable<DeleteBlogPostCategoryDTO>> deleteValidatorList, ILogger<BlogPostCategoryDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
