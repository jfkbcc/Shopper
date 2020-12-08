using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary;
using ShoppingLibrary.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
	public class AdminProductsController : BaseController
    {
        private readonly DatabaseContext dbContext;

        public class CreateProductModel
        {
            public string Name { get; set; }

            public string Image { get; set; }

            public decimal Price { get; set; }

            public string Description { get; set; }
        }

        public class EditProductModel
        {
            public int ProductID { get; set; }

            public string Name { get; set; }

            public string Image { get; set; }

            public decimal Price { get; set; }

            public string Description { get; set; }
        }


        public AdminProductsController(DatabaseContext context)
            : base(context)
        {
            dbContext = context;
        }

        [Route("/Admin/Products")]
        public IActionResult Index()
        {
            // TODO: check to make sure customer is an admin, or redirect out of the panel

            ViewData["ProductList"] = dbContext.Products.ToList();

            return View();
        }

        [Route("/Admin/Products/Create")]
        public ActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        [Route("/Admin/Products/Create")]
        public void CreateProduct(CreateProductModel createProductModel)
        {
            if (ModelState.IsValid && createProductModel != null)
            {
                var product = new Product
                {
                    Name = createProductModel.Name,
                    Image = createProductModel.Image,
                    Description = createProductModel.Description,
                    Price = createProductModel.Price
                };
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }

            HttpContext.Response.Redirect("/Admin/Products");
        }

        [Route("/Admin/Products/{id}")]
        public ActionResult Edit(int id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                HttpContext.Response.Redirect("/Admin/Products");
                return View();
            }

            ViewData["ProductData"] = product;
            return View("Edit");
        }

        [HttpPost]
        [Route("/Admin/Products/{id}")]
        public void EditProduct(EditProductModel editProductModel)
        {
            if (ModelState.IsValid && editProductModel != null)
            {
                var product = dbContext.Products.Find(editProductModel.ProductID);
                if (product != null)
                {
                    product.Name = editProductModel.Name;
                    product.Description = editProductModel.Description;
                    product.Image = editProductModel.Image;
                    product.Price = editProductModel.Price;
                    dbContext.SaveChanges();
                }
            }

            HttpContext.Response.Redirect("/Admin/Products");
        }
    }
}
