using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Presentation.API.Controllers.Abstract;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Cv;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceTechnologyController : Controller<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>
    {
        public ExperienceTechnologyController(IExperienceTechnologyDatabaseService service) : base(service)
        {
        }
    }
}
