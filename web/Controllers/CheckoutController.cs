using System;
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
    public class CheckoutController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public CheckoutController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                    ViewData["ShoppingCart"] = cartManager.shoppingCart.Items.ToList();
            }

            return View();
        }

        // GET: Checkout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Confirm()
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                    ViewData["ShoppingCart"] = cartManager.shoppingCart.Items.ToList();
            }
            return View();
        }

        public ActionResult PlaceOrder()
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                CartManager cartManager = CustomerManager.GetCustomerCart(dbContext, (int)customerId);
                if (cartManager != null)
                {
                    // empty cart
                    // (charge account)
                    // show order successfully placed page

                    cartManager.EmptyCart();
                }
            }

            return View();
        }

        // GET: Checkout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checkout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Checkout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Checkout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Checkout/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}