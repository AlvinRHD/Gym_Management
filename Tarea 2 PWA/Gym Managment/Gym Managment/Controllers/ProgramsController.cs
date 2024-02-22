using Microsoft.AspNetCore.Mvc;

namespace Gym_Managment.Controllers
{
    public class ProgramsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
