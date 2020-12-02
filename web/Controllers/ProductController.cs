using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public ProductController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            ViewData["Products"] = dbContext.Products.ToList();
            return View();
        }

        public IActionResult View(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (product == null)
                return Index();

            ViewData["Product"] = product;
            return View("product");
        }
    }
}
