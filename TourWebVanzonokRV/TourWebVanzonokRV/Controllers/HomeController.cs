using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TourWebVanzonokRV.Models;

namespace TourWebVanzonokRV.Controllers
{
    public class HomeController : Controller
    {
        ItourListVanzonokRV repo;

        public HomeController(ItourListVanzonokRV r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            return View(repo.GetTours());
        }

        public ActionResult Details(int id)
        {
            TourModelVanzonokRV tour = repo.Get(id);
            if (tour != null)
                return View(tour);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TourModelVanzonokRV tour)
        {
            repo.Create(tour);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TourModelVanzonokRV tour = repo.Get(id);
            if (tour != null)
                return View(tour);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(TourModelVanzonokRV tour)
        {
            repo.Update(tour);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            TourModelVanzonokRV tour = repo.Get(id);
            if (tour != null)
                return View(tour);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
