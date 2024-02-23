using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
