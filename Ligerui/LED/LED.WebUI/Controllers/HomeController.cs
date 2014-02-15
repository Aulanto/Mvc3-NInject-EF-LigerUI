using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LED.Domain.IRepository;
using LED.Domain.Entities;
using LED.DataProvider.RepositoryImpl;

namespace LED.WebUI.Controllers
{
    public class HomeController : Controller
    {

       
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Test() {

            return View();
        }

    }
}
