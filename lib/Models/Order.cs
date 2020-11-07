using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingLibrary
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        public string ShippingMethod { get; set; }

        public decimal ShippingCost { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public int BillingAddressID { get; set; }

        public virtual Address BillingAddress { get; set; }

        public int ShippingAddressID { get; set; }

        public virtual Address ShippingAddress { get; set; }

    }
}
