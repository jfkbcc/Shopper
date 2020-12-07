using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingLibrary.Models
{
    [Table("OrderShoppingCartItem")]
    public class OrderShoppingCartItem
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int OrderShoppingCartID { get; set; }

        public virtual OrderShoppingCart OrderShoppingCart { get; set; }
    }
}
