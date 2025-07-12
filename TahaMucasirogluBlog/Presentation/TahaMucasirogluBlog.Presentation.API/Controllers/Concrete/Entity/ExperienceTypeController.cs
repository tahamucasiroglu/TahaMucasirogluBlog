using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Presentation.API.Controllers.Abstract;
using TahaMucasirogluBlog.Presentation.API.Controllers.Base;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceTypeController : Controller<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>
    {
        public ExperienceTypeController(IExperienceTypeDatabaseService service) : base(service)
        {
        }
    }
}
