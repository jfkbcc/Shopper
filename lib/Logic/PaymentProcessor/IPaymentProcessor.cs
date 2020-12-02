using ShoppingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Logic.PaymentProcessor
{
	public interface IPaymentProcessor
	{
		PaymentResponse ChargeOrder(CartManager cart);

		PaymentResponse RefundOrder(Order order);
	}
}
