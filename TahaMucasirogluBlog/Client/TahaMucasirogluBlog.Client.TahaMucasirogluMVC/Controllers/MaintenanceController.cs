using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Options;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly MaintenanceOption model;
        public MaintenanceController(IOptions<MaintenanceOption> model)
        {
            this.model = model.Value;
        }


        public IActionResult Index()
        {
            return View(model);
        }
    }
}
