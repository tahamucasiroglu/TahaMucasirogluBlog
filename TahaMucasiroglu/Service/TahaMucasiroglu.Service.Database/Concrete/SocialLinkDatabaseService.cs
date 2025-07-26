using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink;
using TahaMucasiroglu.Domain.Entities.Concrete.Main;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasiroglu.Service.Database.Abstract;
using TahaMucasiroglu.Service.Database.Base;

namespace TahaMucasiroglu.Service.Database.Concrete
{
    public class SocialLinkDatabaseService : DatabaseService<SocialLink, GetSocialLinkDTO, AddSocialLinkDTO, UpdateSocialLinkDTO, DeleteSocialLinkDTO>, ISocialLinkDatabaseService
    {
        public SocialLinkDatabaseService(ISocialLinkRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSocialLinkDTO> addValidator, IValidator<IEnumerable<AddSocialLinkDTO>> addValidatorList, IValidator<UpdateSocialLinkDTO> updateValidator, IValidator<IEnumerable<UpdateSocialLinkDTO>> updateValidatorList, IValidator<DeleteSocialLinkDTO> deleteValidator, IValidator<IEnumerable<DeleteSocialLinkDTO>> deleteValidatorList, ILogger<SocialLinkDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
