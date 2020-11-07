using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingLibrary
{
    public class Class1
    {
        private static void initializeData(DatabaseContext context)
        {
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

        public static String someFunction()
        {
            var dbcon = new ShoppingContextFactory().CreateDbContext(null);

            if (dbcon.Orders.Count() == 0)
            {
                initializeData(dbcon);
            }

            String ret = "Database Results:<br>";

            //Customer c = dbcon.Customers.Find(2);

            Order o = dbcon.Orders.Find(1);
            Customer c = o.Customer;

            ret += "Shipping Method: " + o.ShippingMethod + "<br>";

            //foreach (Customer c in dbcon.Customers)
            {
                ret += "Customer: " + c.Name + "<br>";
                ret += "Email: " + c.Email + "<br>";
                ret += "Gender: " + c.Gender + "<br>";
                ret += "Birthday: " + c.Birthday.ToString() + "<br>";
                ret += "Street Address: " + o.ShippingAddress.Street + "<br>";
                ret += "<br><br>";
            }

            c.Name = c.Name + "a";
            dbcon.SaveChanges();

            return ret;
        }
    }
}
