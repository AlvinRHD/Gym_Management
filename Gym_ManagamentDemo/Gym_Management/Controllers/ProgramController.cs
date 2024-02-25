using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index() 
        { 
            return View(); 
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Program program)
        {
            if (!ModelState.IsValid)
            {
                return View(program);
            }
        }
    }
}
