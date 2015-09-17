using System;
using System.Collections.Generic;

namespace Project1
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter your name:");
			var aName = Console.ReadLine();
			decimal aBalance = 0m;
			var aTransactionCount = 0;
			var aEvents = new List<string>();
			var aActionLower = string.Empty;

			do
			{
				// greeting and command instructions
				Console.WriteLine("What would you like to do {0}:", aName);
				Console.WriteLine("Balance is ${0:C}", aBalance);
				Console.WriteLine("Interest is 5% and is calculated on the balance every third transaction");
				Console.WriteLine("(D)eposit, (W)ithdrawal, Get (B)alance, (L)ist actions for this session, E(X)it? (not case sensitive)");

				// read console to get command
				var aAction = Console.ReadLine();

				if (string.IsNullOrEmpty(aAction))
					continue;

				aActionLower = aAction.ToLower();

				// do a deposit
				if (aActionLower == "d" || aActionLower == "deposit")
				{
					Console.WriteLine("Enter amount to deposit");
					var aAmountEntered = Console.ReadLine();
					// if nothing was entered then continue
					if (string.IsNullOrEmpty(aAmountEntered))
						continue;
					// if a non-numeric value was entered then continue
					decimal aAmount;
					if (!decimal.TryParse(aAmountEntered, out aAmount))
						continue;
					// increment transaction count
					aTransactionCount++;
					// adjust the balance
					aBalance += aAmount;

					// decide to apply intereset
					if (aTransactionCount % 3 == 0)
						aBalance = aBalance * 1.05m;
					aEvents.Add($"Deposit\tAmount:{aAmount:C}\tBalance:{aBalance:C}");
					// print the balance
					Console.Clear();
					Console.WriteLine("Balance is {0:C}", aBalance);
				}
				// do a withdrawal
				if (aActionLower == "w" || aActionLower == "withdrawal")
				{
					Console.WriteLine("Enter amount to withdrawal");
					var aAmountEntered = Console.ReadLine();
					// if nothing was entered then continue
					if (string.IsNullOrEmpty(aAmountEntered))
						continue;
					// if a non-numeric value was entered then contine
					decimal aAmount;
					if (!decimal.TryParse(aAmountEntered, out aAmount))
						continue;
					// increment the transaction count
					aTransactionCount++;
					Console.Clear();
					if (aAmount > aBalance)
					{
						Console.WriteLine("You don't have that much money in your account {0}", aName);
						continue;
					}
					// adjust the balance
					aBalance -= aAmount;
					// decide to apply interest
					if (aTransactionCount % 3 == 0)
					{
						var aInterest = aBalance * .05m;
						aBalance = aBalance * 1.05m;
						aEvents.Add($"Interest\tAmount:{aInterest:C}\tBalance:{aBalance:C}");
					}
					aEvents.Add($"Withdrawal\tAmount:{aAmount:C}\tBalance:{aBalance:C}");
					// print the balance
					Console.WriteLine("Balance is {0:C}", aBalance);
				}
				// do a balance inquiry
				if (aActionLower == "b" || aActionLower == "balance")
				{
					aEvents.Add($"Balance\tBalance:{aBalance:C}");
					Console.Clear();
					// print the balance
					Console.WriteLine("Balance is {0:C}", aBalance);
				}
				// show the log for the session
				if (aActionLower == "l" || aActionLower == "list")
				{
					aEvents.ForEach(Console.WriteLine);
				}

			} while (aActionLower != "x" && aActionLower != "exit");


			// exit
			Console.WriteLine("Goodbye {0}, press \"Enter\" to exit", aName);
			Console.ReadLine();
		}
	}
}
