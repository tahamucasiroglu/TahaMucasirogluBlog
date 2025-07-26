using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Presentation.CvAPI.Controllers.Base;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Presentation.CvAPI.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillController : CvController<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO>
    {
        public SkillController(IDatabaseService<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO> service) : base(service)
        {
        }
    }

}
