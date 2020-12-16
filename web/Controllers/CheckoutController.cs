using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Logic;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly DatabaseContext dbContext;
        private CartManager cartManager;

        public CheckoutController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        private bool ValidateShoppingCart()
		{
            // Ensure customer is logged in
            if (!CheckAuthentication())
                return false;

            // Make sure the customer has a valid shopping cart (with items in it)
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                {
                    if (cartManager.shoppingCart.Items.Count < 1)
					{
                        string errorMessage = "You must have items in your shopping cart to checkout!";
                        HttpContext.Response.Redirect("/Cart?err=" + WebUtility.UrlEncode(errorMessage));
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            if (!ValidateShoppingCart())
                return View();

            ViewData["ShoppingCart"] = cartManager.shoppingCart.Items.ToList();
            return View();
        }

        // GET: Confirm
        public ActionResult Confirm()
        {
            if (!ValidateShoppingCart())
                return View();

            ViewData["ShoppingCart"] = cartManager.shoppingCart.Items.ToList();
            return View();
        }

        // GET: PlaceOrder
        public ActionResult PlaceOrder()
        {
            if (!ValidateShoppingCart())
                return View();

            // Create a new order for the customer
            cartManager.CreateOrderFromCart();

            return View();
        }
    }
}