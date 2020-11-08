using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingLibrary.Models
{
    [Table("ShoppingCartItem")]
    public class ShoppingCartItem
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int ShoppingCartID { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
