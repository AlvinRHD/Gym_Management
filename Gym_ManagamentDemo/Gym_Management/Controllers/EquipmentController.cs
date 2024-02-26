using Gym_Management.Models;
using Gym_Management.Repositories.Equipment;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult Index()
        {
            return View(_equipmentRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EquipmentModel equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }
            _equipmentRepository.Add(equipment);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var equipment = _equipmentRepository.GetById(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EquipmentModel equipmentModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(equipmentModel);
                }

                _equipmentRepository.Edit(equipmentModel);
                //_customerRepository.Edit(customerModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(equipmentModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var equipment = _equipmentRepository.GetById(id);
            //CustomerRepository customerRepository = new CustomerRepository();
            //var customer = customerRepository.GetById(CustomerID);

            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        [HttpPost]
        public IActionResult Delete(EquipmentModel equipmentModel)
        {

            try
            {
                _equipmentRepository.Delete(equipmentModel.EquipmentID);

                //CustomerRepository customerRepository = new CustomerRepository();
                //customerRepository.Delete(customerModel.CustomerID);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(equipmentModel);
            }
        }
    }
}
