using ClassLibrary1ShoppingCart.Core.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository repo; // sera injecté par Unity

        public ActionResult Index()
        {
            return View(repo.FindAll());
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