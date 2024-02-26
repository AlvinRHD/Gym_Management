using Gym_Management.Models;
using Gym_Management.Repositories.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }
            _customerRepository.Add(customer);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();

        }
    }
}
