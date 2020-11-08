using ShoppingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingLibrary.Logic
{
    public class CartManager
    {
        private DatabaseContext context;

        public Customer customer;

        public ShoppingCart shoppingCart;

        public CartManager(DatabaseContext context, Customer customer)
        {
            this.context = context;
            this.customer = customer;
            this.getShoppingCart();
        }

        private void getShoppingCart()
        {
            var cart = this.context.ShoppingCart.Where(q => q.CustomerID == this.customer.ID).FirstOrDefault();
            if (cart == null)
			{
                cart = new ShoppingCart
                {
                    CustomerID = this.customer.ID
                };

                this.context.ShoppingCart.Add(cart);
                this.context.SaveChanges();
            }

            this.shoppingCart = cart;
		}

        public bool AddToCart(int productId, int quantity)
		{
            ShoppingCartItem item = this.shoppingCart.Items.Where(q => q.ProductID == productId).FirstOrDefault();

            if (item == null)
            {
                item = new ShoppingCartItem
                {
                    ProductID = productId,
                    Quantity = quantity,
                    ShoppingCartID = this.shoppingCart.ID
                };

                this.shoppingCart.Items.Add(item);
                this.context.SaveChanges();
            }
            else
			{
                var newQuantity = item.Quantity + quantity;
                if (newQuantity <= 0)
                    RemoveFromCart(productId);
                else
				{
                    item.Quantity = newQuantity;
                    this.context.SaveChanges();
				}
			}

            return true;
		}

        public bool RemoveFromCart(int productId)
		{
            var item = this.shoppingCart.Items.Where(q => q.ProductID == productId).FirstOrDefault();
            if (item == null)
                return false;

            this.shoppingCart.Items.Remove(item);
            this.context.SaveChanges();
            return true;
        }
    }
}
