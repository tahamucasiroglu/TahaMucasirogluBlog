using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.SocialLink;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinkController : Controller<SocialLink, GetSocialLinkDTO, AddSocialLinkDTO, UpdateSocialLinkDTO, DeleteSocialLinkDTO>
    {
        public SocialLinkController(ISocialLinkDatabaseService service) : base(service)
        {
        }
    }
}
