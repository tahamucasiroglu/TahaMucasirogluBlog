
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Abstract.Cv;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceController : Controller<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>
    {
        public ExperienceController(IExperienceDatabaseService service) : base(service)
        {
        }
    }
}
