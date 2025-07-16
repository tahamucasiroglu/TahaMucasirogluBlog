using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class TagDatabaseService : DatabaseService<Tag, GetTagDTO, AddTagDTO, UpdateTagDTO, DeleteTagDTO>, ITagDatabaseService
    {
        public TagDatabaseService(ITagRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddTagDTO> addValidator, IValidator<IEnumerable<AddTagDTO>> addValidatorList, IValidator<UpdateTagDTO> updateValidator, IValidator<IEnumerable<UpdateTagDTO>> updateValidatorList, IValidator<DeleteTagDTO> deleteValidator, IValidator<IEnumerable<DeleteTagDTO>> deleteValidatorList, ILogger<TagDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
