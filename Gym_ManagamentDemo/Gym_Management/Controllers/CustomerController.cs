using Gym_Management.Models;
using Gym_Management.Repositories.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class CustomerController : Controller
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
        public IActionResult Create(CustomerModel customerModel) 
        {
            CustomerModel customer = new CustomerModel();
            
            if (!ModelState.IsValid)
            {
                return View(customerModel);
            }

            CustomerRepository.Add(customerModel);
        }

        public IActionResult Edit() 
        {
            var customerModel = CustomerModel.GetbyId(id);

            return View(customerModel);
        }
    }
}
