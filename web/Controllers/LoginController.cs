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
    public class AuthenticateModel
    {
        public string Email { get; set; }
    }

    public class RegisterModel
    {
        public string Email { get; set; }

        public string Name { get; set; }
    }

    public class LoginController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public LoginController(DatabaseContext context)
            : base(context)
		{
            dbContext = context;
		}

        public IActionResult Index()
        {
            ViewData["ErrorMsg"] = HttpContext.Request.Query["err"];

            return View();
        }

        public void Logout()
        {
            HttpContext.Session.Remove("customer");
            HttpContext.Response.Redirect("/Login");
        }

        [HttpPost]
        public void Authenticate(AuthenticateModel authenticateModel)
        {
            if (ModelState.IsValid && authenticateModel != null)
            {
                Customer customer = CustomerManager.GetCustomerByEmail(dbContext, authenticateModel.Email);
                if (customer != null)
                {
                    HttpContext.Session.SetInt32("customer", customer.ID);
                    HttpContext.Response.Redirect("/Home");
                    return;
                }
            }

            var errmsg = "User account does not exist, please try again.";
            HttpContext.Response.Redirect("/Login?err=" + WebUtility.UrlEncode(errmsg));
        }

        [HttpPost]
        public void Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid && registerModel != null)
            {
                Customer customer = CustomerManager.GetCustomerByEmail(dbContext, registerModel.Email);
                if (customer == null)
                {
                    // TODO: add password w/ encryption
                    customer = new Customer
                    {
                        Email = registerModel.Email,
                        Name = registerModel.Name,
                        Password = "",
                        IsAdmin = false
                    };
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();

                    HttpContext.Session.SetInt32("customer", customer.ID);
                    HttpContext.Response.Redirect("/Home");
                    return;
                }
                else
                {
                    var errmsg = "An account with that email address already exists, please try logging in.";
                    HttpContext.Response.Redirect("/Login?err=" + WebUtility.UrlEncode(errmsg));
                    return;
                }
            }

            HttpContext.Response.Redirect("/Login");
        }
    }
}
