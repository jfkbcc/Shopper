using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

    }
}
