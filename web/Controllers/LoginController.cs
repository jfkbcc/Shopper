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
    public class AuthenticateModel
    {
        public string Email { get; set; }
    }

    public class RegisterModel
    {
        public string Email { get; set; }

        public string Name { get; set; }
    }

    public class LoginController : Controller
    {
        public IActionResult Index()
        {
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
                Customer customer = CustomerManager.GetCustomerByEmail(authenticateModel.Email);
                if (customer != null)
                {
                    HttpContext.Session.SetInt32("customer", customer.ID);
                    HttpContext.Response.Redirect("/Home");
                    return;
                }
            }

            HttpContext.Response.Redirect("/Login");
        }

        [HttpPost]
        public void Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid && registerModel != null)
            {
                var dbcon = ShoppingContextFactory.get();

                Customer customer = CustomerManager.GetCustomerByEmail(registerModel.Email);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        Email = registerModel.Email,
                        Name = registerModel.Name
                    };
                    dbcon.Customers.Add(customer);
                    dbcon.SaveChanges();
                }
                else
                {
                    if (customer.Name != registerModel.Name)
                    {
                        customer.Name = registerModel.Name;
                        dbcon.SaveChanges();
                    }
                }

                HttpContext.Session.SetInt32("customer", customer.ID);
                HttpContext.Response.Redirect("/Home");
                return;
            }

            HttpContext.Response.Redirect("/Login");
        }
    }
}
