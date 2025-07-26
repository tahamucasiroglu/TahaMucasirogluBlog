using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Concrete.Blog
{
    public class BlogPostCategoryDatabaseService : BlogDatabaseService<BlogPostCategory, GetBlogPostCategoryDTO, AddBlogPostCategoryDTO, UpdateBlogPostCategoryDTO, DeleteBlogPostCategoryDTO>, IBlogPostCategoryDatabaseService
    {
        public BlogPostCategoryDatabaseService(IBlogPostCategoryRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddBlogPostCategoryDTO> addValidator, IValidator<IEnumerable<AddBlogPostCategoryDTO>> addValidatorList, IValidator<UpdateBlogPostCategoryDTO> updateValidator, IValidator<IEnumerable<UpdateBlogPostCategoryDTO>> updateValidatorList, IValidator<DeleteBlogPostCategoryDTO> deleteValidator, IValidator<IEnumerable<DeleteBlogPostCategoryDTO>> deleteValidatorList, ILogger<BlogPostCategoryDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
