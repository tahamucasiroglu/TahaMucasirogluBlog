using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class InfoDatabaseService : DatabaseService<Info, GetInfoDTO, AddInfoDTO, UpdateInfoDTO, DeleteInfoDTO>, IInfoDatabaseService
    {
        public InfoDatabaseService(IRepository<Info> repository, IMapper mapper, IConfiguration configuration, ILogger<DatabaseService<Info, GetInfoDTO>> logger) : base(repository, mapper, configuration, logger)
        {
        }
    }
}
