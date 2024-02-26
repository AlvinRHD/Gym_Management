using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class ProgramController : Controller
    {
        public IActionResult Index() 
        { 
            return View(); 
        }
    }
}
