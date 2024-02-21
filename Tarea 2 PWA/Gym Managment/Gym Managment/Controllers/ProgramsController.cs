using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Managment.Controllers
{
    public class ProgramsController : Controller
    {
        // GET: ProgramsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProgramsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProgramsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProgramsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProgramsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
