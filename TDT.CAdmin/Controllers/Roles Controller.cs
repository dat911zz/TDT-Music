using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TDT.CAdmin.Controllers
{
    public class Roles_Controller : Controller
    {
        // GET: Roles_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Roles_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles_Controller/Create
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

        // GET: Roles_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles_Controller/Edit/5
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

        // GET: Roles_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles_Controller/Delete/5
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
