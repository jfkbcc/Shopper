using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingLibrary;
using ShoppingLibrary.Models;
using System.Net;

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

		protected bool CheckAuthentication(bool withError = true)
		{
			var customerId = HttpContext.Session.GetInt32("customer");
			if (customerId != null)
			{
				Customer customer = dbContext.Customers.Find(customerId);
				if (customer != null)
					return true;
			}

			if (withError)
			{
				string errorLoginMsg = "You must be logged in!";
				HttpContext.Response.Redirect("/Login?err=" + WebUtility.UrlEncode(errorLoginMsg));
			}
			else
			{
				HttpContext.Response.Redirect("/Login");
			}
			return false;
		}
	}
}
