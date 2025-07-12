using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SocialLink;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class SocialLinkDatabaseService : DatabaseService<SocialLink, GetSocialLinkDTO, AddSocialLinkDTO, UpdateSocialLinkDTO, DeleteSocialLinkDTO>, ISocialLinkDatabaseService
    {
        public SocialLinkDatabaseService(ISocialLinkRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddSocialLinkDTO> addValidator, IValidator<IEnumerable<AddSocialLinkDTO>> addValidatorList, IValidator<UpdateSocialLinkDTO> updateValidator, IValidator<IEnumerable<UpdateSocialLinkDTO>> updateValidatorList, IValidator<DeleteSocialLinkDTO> deleteValidator, IValidator<IEnumerable<DeleteSocialLinkDTO>> deleteValidatorList, ILogger<SocialLinkDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
