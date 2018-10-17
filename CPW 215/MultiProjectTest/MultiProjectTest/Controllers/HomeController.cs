using HomeTownZoo.Core;
using HomeTownZoo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiProjectTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Person p = new Person();
            string someZip = "98467";
            if (Validator.IsValidUSZipCode(someZip))
            {

            }
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