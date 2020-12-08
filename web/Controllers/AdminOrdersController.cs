using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
	public class AdminOrdersController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public AdminOrdersController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        [Route("/Admin/Orders")]
        public IActionResult Index()
        {
            // TODO: check to make sure customer is an admin, or redirect out of the panel

            ViewData["OrderList"] = dbContext.Orders.ToList();

            return View();
        }

        [Route("/Admin/Orders/{id}")]
        public ActionResult View(int id)
        {
            var order = dbContext.Orders.Find(id);
            if (order != null)
            {
                var cart = dbContext.OrderShoppingCart.Where(q => q.OrderID == order.ID).FirstOrDefault();
                if (cart != null)
                {
                    ViewData["OrderData"] = order;
                    ViewData["OrderCartData"] = cart.Items.ToList();
                    return View("View");
                }
            }

            HttpContext.Response.Redirect("/Admin/Orders");
            return View();
        }
    }
}
