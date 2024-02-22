using Microsoft.AspNetCore.Mvc;

namespace Gym_Managment.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
