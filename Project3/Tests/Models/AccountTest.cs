using Project3.Models;
using Xunit;

namespace Project3.Tests.Models
{
	public class AccountTest
	{
		private readonly Account _account;
		private readonly EventLog _eventLog;

		public AccountTest()
		{
			_eventLog = new EventLog();
			_account = new Account(10, _eventLog);	// instantiate account for test with interest rate of 10%
		}

		[Fact]
		public void DepositTest()
		{
			_account.Deposit(3);
			Assert.Equal(3, _account.Balance);
		}

		[Fact]
		public void InterestTest()
		{
			_account.Deposit(1);
			_account.Deposit(1);
			_account.Deposit(1);

			Assert.Equal(3.3m, _account.Balance);
		}
	}
}