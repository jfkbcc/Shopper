using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Models
{
    public class OrderShoppingCart
    {
        public OrderShoppingCart()
		{
            Items = new HashSet<OrderShoppingCartItem>();
		}

        public int ID { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

        public virtual ICollection<OrderShoppingCartItem> Items { get; set; }
    }
}
