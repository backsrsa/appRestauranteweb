using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRestaurant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Clientes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Mesa()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Cocinero()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Camarero()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Facturas()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}