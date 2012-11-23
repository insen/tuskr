using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tuskr.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "tuskr - heavy lifting your tasks";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "tuskr";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "contact@tuskr";

            return View();
        }
    }
}
