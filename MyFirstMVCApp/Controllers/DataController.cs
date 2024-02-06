using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMVCApp.Models;


namespace MyFirstMVCApp.Controllers
{
    public class DataController : Controller
    {
        public ActionResult Index()
        {
            Random rnd = new Random();
            SimpleViewModel svm = new SimpleViewModel();
            svm.Number = rnd.Next(1, 1000);

            return View(svm);
        }
    }
}