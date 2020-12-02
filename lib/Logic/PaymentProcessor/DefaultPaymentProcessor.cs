using ShoppingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Logic.PaymentProcessor
{
	public class DefaultPaymentProcessor : IPaymentProcessor
	{
		public PaymentResponse ChargeOrder(CartManager cart)
		{
			PaymentResponse response = new PaymentResponse
			{
				ResponseCode = PaymentResponse.PaymentResponseCode.Approved,
				Amount = cart.GetCartTotal(),
				ErrorMessage = "Success"
			};

			return response;
		}

		public PaymentResponse RefundOrder(Order order)
		{
			PaymentResponse response = new PaymentResponse
			{
				ResponseCode = PaymentResponse.PaymentResponseCode.Approved,
				Amount = order.OrderTotal,
				ErrorMessage = "Success"
			};

			return response;
		}
	}
}
