using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Presentation.CvAPI.Controllers.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.CvAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceTypeController : CvController<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>
    {
        public ExperienceTypeController(IDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO> service) : base(service)
        {
        }
    }

}
