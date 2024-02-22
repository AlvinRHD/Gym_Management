using Microsoft.AspNetCore.Mvc;
using Gym_Managment.Controllers;  // Asegúrate de incluir el espacio de nombres correcto
using Microsoft.Extensions.Configuration;
using Gym_Managment.Models;
using System.Diagnostics;

namespace Gym_Managment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            var customerController = new CustomerController(_configuration);
            return customerController.Create();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
