namespace MV5CApplication.Models
{ 
		public class BankAccount
		{
			private readonly InterestCalculator _interestCalculator;
			private readonly EventLog _eventLog;
			private decimal _balance;

			public BankAccount(int theInterestRate, EventLog theEventLog)
			{
				_interestCalculator = new InterestCalculator(theInterestRate, theEventLog);
				_eventLog = theEventLog;
			}

			/// <summary>
			/// The amount of money in the account
			/// </summary>
			public decimal Balance
			{
				get
				{
					_eventLog.AddLogMessage($"Balance\tBalance:{_balance:C}");
					return _balance;
				}
			}

			/// <summary>
			/// Add money to the account
			/// </summary>
			/// <param name="theAmount">The amound of money to add</param>
			/// <returns>The balance after the deposit is complete</returns>
			public void Deposit(decimal theAmount)
			{
				_balance += theAmount;
				_balance += _interestCalculator.CalculateInterest(_balance);
				_eventLog.AddLogMessage($"Deposit\tAmount:{theAmount:C}\tBalance:{_balance:C}");
			}

			/// <summary>
			/// Removes money from the account
			/// </summary>
			/// <param name="theAmount">The amount of money to remove</param>
			/// <returns>The balance after the withdrawal is complete</returns>
			/// <exception cref="WithdrawalException">Throws WithdrawlException if withdrawal will overdraw the account</exception>
			public void Withdrawal(decimal theAmount)
			{
				if (theAmount > Balance)
					throw new WithdrawalException("withdrawal amount is greater than account balance", theAmount, Balance);

				_balance -= theAmount;
				_balance += _interestCalculator.CalculateInterest(_balance);
				_eventLog.AddLogMessage($"Withdrawal\tAmount:{theAmount:C}\tBalance:{_balance:C}");
			}
		}
}
