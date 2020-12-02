using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingLibrary;
using ShoppingLibrary.Models;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : BaseController
    {
        private readonly DatabaseContext dbContext;
        private readonly ILogger<HomeController> logger;

        public HomeController(DatabaseContext context, ILogger<HomeController> logger)
            : base(context)
        {
            this.dbContext = context;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            if (!CheckAuthentication())
                return View();

            var customerId = HttpContext.Session.GetInt32("customer");
            if (customerId != null)
            {
                Customer c = dbContext.Customers.Find(customerId);
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
                Customer customer = dbContext.Customers.Find(customerId);
                if (customer != null)
                    return true;
            }

            HttpContext.Response.Redirect("/Login");
            return false;
        }
    }
}
