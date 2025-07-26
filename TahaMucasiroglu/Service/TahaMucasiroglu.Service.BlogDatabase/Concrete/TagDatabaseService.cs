using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Tag;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Base;

namespace TahaMucasiroglu.Service.Database.Concrete.Blog
{
    public class TagDatabaseService : BlogDatabaseService<Tag, GetTagDTO, AddTagDTO, UpdateTagDTO, DeleteTagDTO>, ITagDatabaseService
    {
        public TagDatabaseService(ITagRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddTagDTO> addValidator, IValidator<IEnumerable<AddTagDTO>> addValidatorList, IValidator<UpdateTagDTO> updateValidator, IValidator<IEnumerable<UpdateTagDTO>> updateValidatorList, IValidator<DeleteTagDTO> deleteValidator, IValidator<IEnumerable<DeleteTagDTO>> deleteValidatorList, ILogger<TagDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
