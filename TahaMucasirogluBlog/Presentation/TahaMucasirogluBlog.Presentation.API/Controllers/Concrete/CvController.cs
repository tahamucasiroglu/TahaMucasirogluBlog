using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Service.Cv.Abstract;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Concrete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvService cvService;
        public CvController(ICvService cvService)
        {
            this.cvService = cvService;
        }


        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok();
        }








    }
}
