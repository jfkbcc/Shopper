using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
	public class AdminUsersController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public AdminUsersController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        [Route("/Admin/Users")]
        public IActionResult Index()
        {
            // TODO: check to make sure customer is an admin, or redirect out of the panel

            ViewData["CustomerList"] = dbContext.Customers.ToList();

            return View();
        }
    }
}
