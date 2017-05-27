using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageMovies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application is to Mainitain Movies information.You can create your own movies list and you can modify the details.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Me.";

            return View();
        }
    }
}