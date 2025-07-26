using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Presentation.CvAPI.Controllers.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.CvAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceTechnologyController : CvController<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>
    {
        public ExperienceTechnologyController(IDatabaseService<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO> service) : base(service)
        {
        }
    }

}
