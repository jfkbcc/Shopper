using ShoppingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingLibrary.Logic
{
    public class CustomerManager
    {
        public static Customer GetCustomerById(int id)
        {
            var db = ShoppingContextFactory.get();
            return db.Customers.Find(id);
        }

        public static Customer GetCustomerByEmail(string email)
        {
            var db = ShoppingContextFactory.get();
            return db.Customers.Where(q => q.Email == email).FirstOrDefault();
        }

        public static CartManager GetCustomerCart(int id)
        {
            var db = ShoppingContextFactory.get();
            var customer = db.Customers.Find(id);
            if (customer != null)
                return new CartManager(db, customer);

            return null;
        }
    }
}
