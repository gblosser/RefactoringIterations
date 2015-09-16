namespace Project2.model
{
	public class InterestCalculator
	{
		private int _transactionCounter = 0;
		private readonly EventLog _eventLog;

		/// <summary>
		/// Creates an instance of InterestCalculator
		/// </summary>
		/// <param name="theInterestRate">The interest rate in percent</param>
		/// <param name="theEventLog">Event log for record keeping</param>
		public InterestCalculator(int theInterestRate, EventLog theEventLog)
		{
			InterestRate = theInterestRate;
			_eventLog = theEventLog;
		}

		/// <summary>
		/// The interest rate (in percent)
		/// </summary>
		public int InterestRate { get; }

		/// <summary>
		/// Calculates interest at the proper interval
		/// </summary>
		/// <param name="thePrincipal">The principal to compute interest upon</param>
		/// <returns></returns>
		public decimal CalculateInterest(decimal thePrincipal)
		{
			_transactionCounter ++;

			if (_transactionCounter%3 == 0)
			{
				var aInterestFloat = (float)InterestRate/100;
				var aInterest = (float)thePrincipal*aInterestFloat;
				_eventLog.AddLogMessage($"Interest\tAmount:{aInterest:C}\tBalance:{thePrincipal:C}");
				return (decimal)aInterest;
			}

			return 0m;
		}
	}
}