using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingLibrary;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
	public class BaseController : Controller
	{
		private readonly DatabaseContext dbContext;

		public BaseController(DatabaseContext context)
		{
			this.dbContext = context;
		}

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var customerId = HttpContext.Session.GetInt32("customer");
			if (customerId != null)
			{
				Customer c = dbContext.Customers.Find(customerId);
				if (c != null)
					ViewData["Customer"] = c;
			}

			base.OnActionExecuted(context);
		}
	}
}
