using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPost;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Concrete.Blog
{
    public class BlogPostDatabaseService : BlogDatabaseService<BlogPost, GetBlogPostDTO, AddBlogPostDTO, UpdateBlogPostDTO, DeleteBlogPostDTO>, IBlogPostDatabaseService
    {
        public BlogPostDatabaseService(IBlogPostRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddBlogPostDTO> addValidator, IValidator<IEnumerable<AddBlogPostDTO>> addValidatorList, IValidator<UpdateBlogPostDTO> updateValidator, IValidator<IEnumerable<UpdateBlogPostDTO>> updateValidatorList, IValidator<DeleteBlogPostDTO> deleteValidator, IValidator<IEnumerable<DeleteBlogPostDTO>> deleteValidatorList, ILogger<BlogPostDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
