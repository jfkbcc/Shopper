using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShoppingLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!CheckAuthentication())
                return View();

            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                var dbcon = ShoppingContextFactory.get();

                Customer c = dbcon.Customers.Find(customerId);
                ViewData["Customer"] = c;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool CheckAuthentication()
        {
            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                var dbcon = ShoppingContextFactory.get();

                Customer customer = dbcon.Customers.Find(customerId);
                if (customer != null)
                    return true;
            }

            HttpContext.Response.Redirect("/Login");
            return false;
        }
    }
}
