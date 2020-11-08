using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary.Logic;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart((int)customerId);
                if (cartManager != null)
                    ViewData["ShoppingCart"] = cartManager.shoppingCart.Items.ToList();
            }

            return View();
        }

        [HttpPost]
        public void AddToCart(int product)
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart((int)customerId);
                if (cartManager != null)
                    cartManager.AddToCart(product, 1);
            }

            HttpContext.Response.Redirect("/Cart/Index");
        }

        [HttpPost]
        public void RemoveFromCart(int product)
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart((int)customerId);
                if (cartManager != null)
                    cartManager.RemoveFromCart(product);
            }

            HttpContext.Response.Redirect("/Cart/Index");
        }
    }
}
