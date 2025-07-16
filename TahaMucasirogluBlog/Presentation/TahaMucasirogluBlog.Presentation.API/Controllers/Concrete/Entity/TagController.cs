using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Blog;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TagController : Controller<Tag, GetTagDTO, AddTagDTO, UpdateTagDTO, DeleteTagDTO>
    {
        public TagController(ITagDatabaseService service) : base(service)
        {
        }
    }
}
