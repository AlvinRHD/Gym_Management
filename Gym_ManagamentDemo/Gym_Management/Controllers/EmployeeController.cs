using Gym_Management.Models;
using Gym_Management.Repositories.Customer;
using Gym_Management.Repositories.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private object employeeModel;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View(_employeeRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _employeeRepository.Add(employee);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int CustomerID)
        {
            var customer = _employeeRepository.GetById(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employeeModel);
                }

                _employeeRepository.Edit(employeeModel);
                //_customerRepository.Edit(customerModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(employeeModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int EmployeeID)
        {
            var employee = _employeeRepository.GetById(EmployeeID);
            //CustomerRepository customerRepository = new CustomerRepository();
            //var customer = customerRepository.GetById(CustomerID);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(EmployeeModel employeeModel)
        {
            try
            {
                _employeeRepository.Delete(employeeModel.EmployeeID);

                //CustomerRepository customerRepository = new CustomerRepository();
                //customerRepository.Delete(customerModel.CustomerID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(employeeModel);
            }
        }
    }
}
