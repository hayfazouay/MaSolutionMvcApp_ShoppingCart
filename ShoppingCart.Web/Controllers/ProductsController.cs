using ShoppingCart.Core.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Core.Domain;

namespace ShoppingCart.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository repo; // sera injecté par Unity

        public ProductsController(IProductsRepository repo)
        {
            this.repo = repo;
        }
        public ActionResult Index()
        {
            return View(repo.FindAll());
        }

        public ActionResult AddToCart(string id)
        {
            List<Item> panier = null;
            Product produit = repo.FindAll().FirstOrDefault(p => p.ProductId.Equals(id));
            if (Session["cart"] == null)
            {
                panier = new List<Item> {new Item
                {
                    Product = produit,
                    Quantity = 1
                }
                };
                Session["cart"] = panier;
            }
            else
            {
                panier = (List<Item>)Session["cart"];
                var item = panier.Find(i => i.Product.ProductId.Equals(id));
                if (item == null)
                {
                    panier.Add(new Item
                    {
                        Product = produit,
                        Quantity = 1
                    });
                }
                else
                {
                    item.Quantity++;
                }
            }

            return View("Panier", panier);

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