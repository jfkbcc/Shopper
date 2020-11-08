using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingLibrary.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime? Birthday { get; set; }

        //public Address BillingAddress { get; }

        //public Address ShippingAddress { get; }

    }
}
