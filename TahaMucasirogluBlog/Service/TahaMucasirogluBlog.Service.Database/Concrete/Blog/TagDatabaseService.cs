using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Tag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Blog;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete.Blog
{
    public class TagDatabaseService : BlogDatabaseService<Tag, GetTagDTO, AddTagDTO, UpdateTagDTO, DeleteTagDTO>, ITagDatabaseService
    {
        public TagDatabaseService(ITagRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddTagDTO> addValidator, IValidator<IEnumerable<AddTagDTO>> addValidatorList, IValidator<UpdateTagDTO> updateValidator, IValidator<IEnumerable<UpdateTagDTO>> updateValidatorList, IValidator<DeleteTagDTO> deleteValidator, IValidator<IEnumerable<DeleteTagDTO>> deleteValidatorList, ILogger<TagDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
