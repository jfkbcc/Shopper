using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using ShoppingLibrary.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingLibrary
{
    public class Class1
    {
        public static void initializeProducts()
        {
            var con = ShoppingContextFactory.get();
            if (con.Products.Any())
                return;

            Product product = new Product
            {
                Name = "Apple iPhone XR (Red, 128 GB)",
                Description = "128 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 650.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            };
            con.Products.Add(product);

            product = new Product
            {
                Name = "Apple iPhone XR (Red, 256 GB)",
                Description = "256 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 750.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            };
            con.Products.Add(product);

            product = new Product
            {
                Name = "Apple iPhone XR (Red, 512 GB)",
                Description = "512 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 850.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            };
            con.Products.Add(product);

            con.SaveChanges();
        }
    }
}
