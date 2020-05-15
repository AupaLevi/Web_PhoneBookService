using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using PhoneBookService.Models;

namespace PhoneBookService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PhoneBookSQLConnector phoneBookSQLConnector = new PhoneBookSQLConnector();
            
            return View();
        }

        public ActionResult About()
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