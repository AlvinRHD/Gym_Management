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
            return View(_customerRepository.GetAll());
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerModel customerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(customerModel);
                }

                _customerRepository.Edit(customerModel);
                //_customerRepository.Edit(customerModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(customerModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            //CustomerRepository customerRepository = new CustomerRepository();
            //var customer = customerRepository.GetById(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(CustomerModel customerModel)
        {
            
            try
            {
                _customerRepository.Delete(customerModel.CustomerID);

                //CustomerRepository customerRepository = new CustomerRepository();
                //customerRepository.Delete(customerModel.CustomerID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(customerModel);
            }
        }
    }
}
