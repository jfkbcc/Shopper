using ShoppingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingLibrary.Logic
{
    public class CustomerManager
    {
        public static Customer GetCustomerById(DatabaseContext db, int id)
        {
            return db.Customers.Find(id);
        }

        public static Customer GetCustomerByEmail(DatabaseContext db, string email)
        {
            return db.Customers.Where(q => q.Email == email).FirstOrDefault();
        }

        public static CartManager GetCustomerCart(DatabaseContext db, int id)
        {
            var customer = db.Customers.Find(id);
            if (customer != null)
                return new CartManager(db, customer);

            return null;
        }
    }
}
