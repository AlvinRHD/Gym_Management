using Microsoft.AspNetCore.Mvc;

namespace Gym_Managment.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
