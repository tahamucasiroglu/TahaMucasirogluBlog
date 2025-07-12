
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

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
