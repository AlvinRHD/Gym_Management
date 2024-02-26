using Gym_Management.Models;
using Gym_Management.Repositories.Program;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramRepository _programRepository;

        public ProgramController(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public IActionResult Index()
        {
            return View(_programRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramModel program)
        {
            if(!ModelState.IsValid)
            {
                return View(program);
            }
            _programRepository.Add(program);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var program = _programRepository.GetById(id);

            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProgramModel programModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(programModel);
                }

                _programRepository.Edit(programModel);
                //_customerRepository.Edit(customerModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(programModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _programRepository.GetById(id);
            //CustomerRepository customerRepository = new CustomerRepository();
            //var customer = customerRepository.GetById(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(ProgramModel programModel)
        {

            try
            {
                _programRepository.Delete(programModel.ProgramsID);

                //CustomerRepository customerRepository = new CustomerRepository();
                //customerRepository.Delete(customerModel.CustomerID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(programModel);
            }
        }
    }
}

