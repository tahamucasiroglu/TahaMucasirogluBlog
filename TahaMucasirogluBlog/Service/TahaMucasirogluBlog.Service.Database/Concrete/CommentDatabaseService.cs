using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Comment;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete
{
    public class CommentDatabaseService : DatabaseService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>, ICommentDatabaseService
    {
        public CommentDatabaseService(ICommentRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddCommentDTO> addValidator, IValidator<IEnumerable<AddCommentDTO>> addValidatorList, IValidator<UpdateCommentDTO> updateValidator, IValidator<IEnumerable<UpdateCommentDTO>> updateValidatorList, IValidator<DeleteCommentDTO> deleteValidator, IValidator<IEnumerable<DeleteCommentDTO>> deleteValidatorList, ILogger<CommentDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
