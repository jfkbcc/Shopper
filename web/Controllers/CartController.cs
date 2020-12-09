﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Logic;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
    public class CartController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public CartController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            if (!CheckAuthentication())
                return View();

            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                    ViewData["ShoppingCart"] = cartManager.shoppingCart.Items.ToList();
            }

            ViewData["ErrorMsg"] = HttpContext.Request.Query["err"];
            return View();
        }

        [HttpPost]
        public void AddToCart(int product)
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
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
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                    cartManager.RemoveFromCart(product);
            }

            HttpContext.Response.Redirect("/Cart/Index");
        }

        public void Empty()
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                   cartManager.EmptyCart();
            }
            HttpContext.Response.Redirect("/Home/Index");
        }
    }
}
