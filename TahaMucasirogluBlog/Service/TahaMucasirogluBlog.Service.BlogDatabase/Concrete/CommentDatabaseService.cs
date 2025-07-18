﻿using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Comment;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract.Base;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.BlogDatabase.Abstract;
using TahaMucasirogluBlog.Service.BlogDatabase.Base;

namespace TahaMucasirogluBlog.Service.Database.Concrete.Blog
{
    public class CommentDatabaseService : BlogDatabaseService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>, ICommentDatabaseService
    {
        public CommentDatabaseService(ICommentRepository repository, IMapper mapper, IConfiguration configuration, IValidator<AddCommentDTO> addValidator, IValidator<IEnumerable<AddCommentDTO>> addValidatorList, IValidator<UpdateCommentDTO> updateValidator, IValidator<IEnumerable<UpdateCommentDTO>> updateValidatorList, IValidator<DeleteCommentDTO> deleteValidator, IValidator<IEnumerable<DeleteCommentDTO>> deleteValidatorList, ILogger<CommentDatabaseService> logger) : base(repository, mapper, configuration, addValidator, addValidatorList, updateValidator, updateValidatorList, deleteValidator, deleteValidatorList, logger)
        {
        }
    }
}
