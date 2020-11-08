using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ShoppingLibrary.Class1.initializeProducts();

            var con = ShoppingContextFactory.get();
            ViewData["Products"] = con.Products.ToList();
            return View();
        }

        public IActionResult View(int id)
        {

            var con = ShoppingContextFactory.get();
            Product product = con.Products.Find(id);
            if (product == null)
                return Index();

            ViewData["Product"] = product;
            return View("product");
        }
    }
}
