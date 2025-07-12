
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Comment;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : Controller<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>
    {
        public CommentController(ICommentDatabaseService service) : base(service)
        {
        }
    }
}
