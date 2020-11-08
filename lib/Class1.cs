using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using ShoppingLibrary.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingLibrary
{
    public class Class1
    {
        public static void initializeProducts()
        {
            var con = ShoppingContextFactory.get();
            if (con.Products.Count() > 0)
                return;

            Product product = new Product
            {
                Name = "Apple iPhone XR (Red, 128 GB)",
                Description = "128 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 650.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            };
            con.Products.Add(product);

            product = new Product
            {
                Name = "Apple iPhone XR (Red, 256 GB)",
                Description = "256 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 750.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            };
            con.Products.Add(product);

            product = new Product
            {
                Name = "Apple iPhone XR (Red, 512 GB)",
                Description = "512 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 850.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            };
            con.Products.Add(product);

            con.SaveChanges();
        }

        public static void initializeData(DatabaseContext context)
        {
            if (context.Orders.Count() > 0)
                return;

            Address address = new Address
            {
                Street = "2800 Victory Blvd",
                City = "Staten Island",
                State = "NY",
                ZipCode = "10314",
                Country = "US"
            };
            //context.Addresses.Add(address);
            //context.SaveChanges();

            Customer cust = new Customer
            {
                Name = "Joseph",
                Email = "joseph@csi.com",
                Birthday = DateTime.Parse("2000-05-15"),
                Gender = "M"
            };
            context.Customers.Add(cust);
            context.SaveChanges();

            Order order = new Order
            {
                CustomerID = cust.ID,
                ShippingMethod = "ground",
                ShippingCost = 10.95M,
                BillingAddress = address,
                ShippingAddress = address
            };
            context.Orders.Add(order);

            context.SaveChanges();
        }

        public class ReturnData
        {
            public String ret { get; set; }
            public int cust { get; set; }
        }

        public static ReturnData someFunction(int customerId)
        {
            var dbcon = new ShoppingContextFactory().CreateDbContext(null);
            initializeData(dbcon);

            String ret = "Database Results:<br>";

            Customer c = dbcon.Customers.Find(customerId);

            //Order o = dbcon.Orders.Find(1);
            //Customer c = o.Customer;

            //ret += "Shipping Method: " + o.ShippingMethod + "<br>";

            //foreach (Customer c in dbcon.Customers)
            {
                ret += "Customer: " + c.Name + "<br>";
                ret += "Email: " + c.Email + "<br>";
                ret += "Gender: " + c.Gender + "<br>";
                ret += "Birthday: " + c.Birthday.ToString() + "<br>";
                //ret += "Street Address: " + o.ShippingAddress.Street + "<br>";
                ret += "<br><br>";
            }

            c.Name = c.Name + "a";
            dbcon.SaveChanges();

            return new ReturnData {
                ret = ret,
                cust = c.ID
            };

            //return ret;
        }
    }
}
