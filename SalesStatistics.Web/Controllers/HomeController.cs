using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesStatistics.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sales Statistics Application.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pavel Talochka.";

            return View();
        }
    }
}