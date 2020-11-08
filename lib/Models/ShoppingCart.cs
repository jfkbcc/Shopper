using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
		{
            Items = new HashSet<ShoppingCartItem>();
		}

        public int ID { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}
