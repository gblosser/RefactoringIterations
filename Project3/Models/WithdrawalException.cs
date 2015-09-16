using System;

namespace Project3.Models
{
	public class WithdrawalException : ApplicationException
	{
		public WithdrawalException(string theMessage, decimal theWithdrawalAmount, decimal theAccountBalance) : base(theMessage)
		{
			WithdrawalAmount = theWithdrawalAmount;
			AccountBalance = theAccountBalance;
		}

		public decimal WithdrawalAmount { get; private set; }
		public decimal AccountBalance { get; private set; }
	}
}