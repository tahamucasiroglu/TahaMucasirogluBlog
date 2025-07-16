using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class InfoDatabaseService : DatabaseService<Info, GetInfoDTO, AddInfoDTO, UpdateInfoDTO, DeleteInfoDTO>, IInfoDatabaseService
    {
        public InfoDatabaseService(IInfoRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddInfoDTO> addValidator, IValidator<IEnumerable<AddInfoDTO>> addValidatorList, IValidator<UpdateInfoDTO> updateValidator, IValidator<IEnumerable<UpdateInfoDTO>> updateValidatorList, IValidator<DeleteInfoDTO> deleteValidator, IValidator<IEnumerable<DeleteInfoDTO>> deleteValidatorList, ILogger<InfoDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
