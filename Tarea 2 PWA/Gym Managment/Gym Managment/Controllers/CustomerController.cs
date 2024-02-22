using Microsoft.AspNetCore.Mvc;

namespace Gym_Managment.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
