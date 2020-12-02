using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary.Logic.PaymentProcessor
{
	public class PaymentResponse
	{
		public enum PaymentResponseCode
		{
			Invalid,
			Approved,
			Declined,
			Error
		};

		public PaymentResponseCode ResponseCode = PaymentResponseCode.Invalid;

		public decimal Amount { get; set; }

		public String ErrorMessage { get; set; }
	}
}
