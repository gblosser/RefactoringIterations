using System;

namespace Project2.model
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