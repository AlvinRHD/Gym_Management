using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
