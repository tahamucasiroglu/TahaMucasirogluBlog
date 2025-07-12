using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TahaMucasirogluBlog.Client.Admin.TahaMucasirogluMVC.Options;

namespace TahaMucasirogluBlog.Client.Admin.TahaMucasirogluMVC.Controllers
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
