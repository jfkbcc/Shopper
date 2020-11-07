using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}
