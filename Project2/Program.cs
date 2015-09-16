using System;
using Project2.model;

namespace Project2
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var aInterestRate = 5;
			var aEventLog = new EventLog();
			var aAccount = new Account(aInterestRate, aEventLog);
			var aActionLower = string.Empty;

			Console.WriteLine("Enter your name:");
			var aName = Console.ReadLine();

			do
			{
				var aAction = GetAction(aName, aAccount, aInterestRate);

				if (string.IsNullOrEmpty(aAction))
					continue;

				aActionLower = aAction.ToLower();

				// do a deposit
				if (aActionLower == "d" || aActionLower == "deposit")
				{
					MakeDeposit(aAccount);
				}
				// do a withdrawal
				if (aActionLower == "w" || aActionLower == "withdrawal")
				{
					MakeWithdrawal(aAccount);
				}
				// do a balance inquiry
				if (aActionLower == "b" || aActionLower == "balance")
				{
					Console.Clear();
					// print the balance
					Console.WriteLine("Balance is {0:C}", aAccount.GetBalance());
				}
				// show the log for the session
				if (aActionLower == "l" || aActionLower == "list")
				{
					aEventLog.Events.ForEach(Console.WriteLine);
				}

			} while (aActionLower != "x" && aActionLower != "exit");

			// exit
			Console.WriteLine("Goodbye {0}, press \"Enter\" to exit", aName);
			Console.ReadLine();
		}


		/// <summary>
		/// Displays instructions to the user
		/// </summary>
		/// <param name="aName">the name of the user</param>
		/// <param name="aAccount">the account the user is working with</param>
		/// <param name="aInterestRate">the interest rate of the account</param>
		/// <returns>a string input by the user indicating the action to take</returns>
		private static string GetAction(string aName, Account aAccount, int aInterestRate)
		{
			// greeting and instructions
			Console.WriteLine("What would you like to do {0}:", aName);
			Console.WriteLine("Balance is {0:C}", aAccount.GetBalance());
			Console.WriteLine("Interest is {0}% and is calculated on the balance every third transaction", aInterestRate);
			Console.WriteLine(
				"(D)eposit, (W)ithdrawal, Get (B)alance, (L)ist actions for this session, E(X)it? (not case sensitive)");

			// read console
			var aAction = Console.ReadLine();
			return aAction;
		}

		private static void MakeDeposit(Account aAccount)
		{
			Console.WriteLine("Enter amount to deposit");
			var aAmountEntered = Console.ReadLine();
			// if nothing was entered then continue
			if (string.IsNullOrEmpty(aAmountEntered))
				return;
			// if a non-numeric value was entered then continue
			decimal aAmount;
			if (!decimal.TryParse(aAmountEntered, out aAmount))
				return;

			// adjust the balance
			aAccount.Deposit(aAmount);

			// print the balance
			Console.Clear();
			Console.WriteLine("Balance is {0:C}", aAccount.GetBalance());
		}

		private static void MakeWithdrawal(Account aAccount)
		{
			Console.WriteLine("Enter amount to withdrawal");
			var aAmountEntered = Console.ReadLine();
			// if nothing was entered then continue
			if (string.IsNullOrEmpty(aAmountEntered))
				return;
			// if a non-numeric value was entered then contine
			decimal aAmount;
			if (!decimal.TryParse(aAmountEntered, out aAmount))
				return;

			Console.Clear();
			// adjust the balance
			try
			{
				aAccount.Withdrawal(aAmount);
			}
			catch (WithdrawalException ex)
			{
				Console.WriteLine(
					"Withdrawal {0:C} is greater than your account balance {1:C}, cannot complete the action",
					ex.WithdrawalAmount, ex.AccountBalance);
				return;
			}

			// print the balance
			Console.WriteLine("Balance is {0:C}", aAccount.GetBalance());
		}
	}
}
