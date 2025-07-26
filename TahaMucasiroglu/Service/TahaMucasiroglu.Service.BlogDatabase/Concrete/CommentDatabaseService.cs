using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Comment;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract.Base;
using TahaMucasiroglu.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Abstract;
using TahaMucasiroglu.Service.BlogDatabase.Base;

namespace TahaMucasiroglu.Service.Database.Concrete.Blog
{
    public class CommentDatabaseService : BlogDatabaseService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>, ICommentDatabaseService
    {
        public CommentDatabaseService(ICommentRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddCommentDTO> addValidator, IValidator<IEnumerable<AddCommentDTO>> addValidatorList, IValidator<UpdateCommentDTO> updateValidator, IValidator<IEnumerable<UpdateCommentDTO>> updateValidatorList, IValidator<DeleteCommentDTO> deleteValidator, IValidator<IEnumerable<DeleteCommentDTO>> deleteValidatorList, ILogger<CommentDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
