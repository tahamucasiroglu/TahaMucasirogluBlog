using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Presentation.CvAPI.Controllers.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.CvAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceController : CvController<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>
    {
        public ExperienceController(IDatabaseService<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO> service) : base(service)
        {
        }
    }
}
