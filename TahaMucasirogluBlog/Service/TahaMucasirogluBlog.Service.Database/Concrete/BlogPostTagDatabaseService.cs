using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostTag;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class BlogPostTagDatabaseService : DatabaseService<BlogPostTag, GetBlogPostTagDTO, AddBlogPostTagDTO, UpdateBlogPostTagDTO, DeleteBlogPostTagDTO>, IBlogPostTagDatabaseService
    {
        public BlogPostTagDatabaseService(
            IBlogPostTagRepository repository, 
            IMapper mapper, 
            IConfiguration configuration,
            IValidator<AddBlogPostTagDTO> addValidator, 
            IValidator<IEnumerable<AddBlogPostTagDTO>> addValidatorList, 
            IValidator<UpdateBlogPostTagDTO> updateValidator, 
            IValidator<IEnumerable<UpdateBlogPostTagDTO>> updateValidatorList, 
            IValidator<DeleteBlogPostTagDTO> deleteValidator, 
            IValidator<IEnumerable<DeleteBlogPostTagDTO>> deleteValidatorList, 
            ILogger<BlogPostTagDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
