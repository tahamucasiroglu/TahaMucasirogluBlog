using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Abstract.Blog;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.BlogDatabase.Base
{

    public abstract class BlogDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : DatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>, IBlogDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest>
      where TEntity : class, IBlogEntity
      where TResponse : class, IBlogGetDTO
       where TAddRequest : class, IBlogAddDTO
        where TUpdateRequest : class, IBlogUpdateDTO
        where TDeleteRequest : class, IBlogDeleteDTO
    {
        public BlogDatabaseService(
            IBlogRepository<TEntity> repository,
            IMapper mapper,
            IConfiguration configuration,
            IValidator<TAddRequest> addValidator,
            IValidator<IEnumerable<TAddRequest>> addValidatorList,
            IValidator<TUpdateRequest> updateValidator,
            IValidator<IEnumerable<TUpdateRequest>> updateValidatorList,
            IValidator<TDeleteRequest> deleteValidator,
            IValidator<IEnumerable<TDeleteRequest>> deleteValidatorList,
            ILogger<DatabaseService<TEntity, TResponse>> logger) :
            base(
                repository,
                mapper,
                configuration,
                addValidator,
                addValidatorList,
                updateValidator,
                updateValidatorList,
                deleteValidator,
                deleteValidatorList,
                logger)
        {
        }

    }
}
