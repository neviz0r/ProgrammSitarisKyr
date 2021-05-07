using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TourWebVanzonokRV.Models;

namespace TourWebVanzonokRV.Controllers
{
    public class OrdersController : Controller
    {
        IorderListVanzonokRV repoO;
        public OrdersController(IorderListVanzonokRV rO)
        {
            repoO = rO;
        }

        public IActionResult Privacy()
        {
            return View(repoO.GetOrders());
        }

        public ActionResult DetailsO(int id)
        {
            OrderModelVanzonokRV order = repoO.Get(id);
            if (order != null)
                return View(order);
            return NotFound();
        }

        public ActionResult CreateO()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateO(OrderModelVanzonokRV order)
        {
            repoO.CreateO(order);
            return RedirectToAction("Privacy");
        }

        public ActionResult EditO(int id)
        {
            OrderModelVanzonokRV order = repoO.Get(id);
            if (order != null)
                return View(order);
            return NotFound();
        }

        [HttpPost]
        public ActionResult EditO(OrderModelVanzonokRV order)
        {
            repoO.UpdateO(order);
            return RedirectToAction("Privacy");
        }

        [HttpGet]
        [ActionName("DeleteO")]
        public ActionResult ConfirmDeleteO(int id)
        {
            OrderModelVanzonokRV order = repoO.Get(id);
            if (order != null)
                return View(order);
            return NotFound();
        }
        [HttpPost]
        public ActionResult DeleteO(int id)
        {
            repoO.DeleteO(id);
            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
