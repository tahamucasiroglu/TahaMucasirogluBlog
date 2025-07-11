using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class TagDatabaseService : DatabaseService<Tag, GetTagDTO, AddTagDTO, UpdateTagDTO, DeleteTagDTO>, ITagDatabaseService
    {
        public TagDatabaseService(ITagRepository repository, IMapper mapper, IConfiguration configuration, ILogger<TagDatabaseService> logger) : base(repository, mapper, configuration, logger)
        {
        }
    }
}
