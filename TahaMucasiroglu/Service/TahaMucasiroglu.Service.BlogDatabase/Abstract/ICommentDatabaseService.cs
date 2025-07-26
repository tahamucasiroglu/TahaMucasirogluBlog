using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Comment;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Abstract
{
    public interface ICommentDatabaseService : IBlogDatabaseService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>
    {
    }
}
