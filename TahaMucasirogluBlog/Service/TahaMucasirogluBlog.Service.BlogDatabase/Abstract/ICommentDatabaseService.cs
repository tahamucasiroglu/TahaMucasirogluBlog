using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Comment;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.BlogDatabase.Abstract
{
    public interface ICommentDatabaseService : IBlogDatabaseService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>
    {
    }
}
