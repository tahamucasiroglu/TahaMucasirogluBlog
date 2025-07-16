using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPost;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class BlogPostDatabaseService : DatabaseService<BlogPost, GetBlogPostDTO, AddBlogPostDTO, UpdateBlogPostDTO, DeleteBlogPostDTO>, IBlogPostDatabaseService
    {
        public BlogPostDatabaseService(IBlogPostRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddBlogPostDTO> addValidator, IValidator<IEnumerable<AddBlogPostDTO>> addValidatorList, IValidator<UpdateBlogPostDTO> updateValidator, IValidator<IEnumerable<UpdateBlogPostDTO>> updateValidatorList, IValidator<DeleteBlogPostDTO> deleteValidator, IValidator<IEnumerable<DeleteBlogPostDTO>> deleteValidatorList, ILogger<BlogPostDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
