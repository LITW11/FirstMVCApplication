using MyFirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApp.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult Index()
        {
            NorthwindDbManager mgr = new NorthwindDbManager(Properties.Settings.Default.ConStr);
            ProductsViewModel vm = new ProductsViewModel();
            vm.Products = mgr.GetProducts();
            vm.CategoryCount = mgr.GetCategoryCount();

            return View(vm);
        }
    }
}