using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
	public class AdminController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public AdminController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            // TODO: check to make sure customer is an admin, or redirect out of the panel

            return View();
        }
    }
}
