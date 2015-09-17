using Project3.Models;
using Xunit;

namespace Project3.Tests.Models
{
	public class AccountRepositoryTest
	{
		private readonly IAccountRepository _repository;
		private readonly EventLog _eventLog;

		public AccountRepositoryTest()
		{
			_eventLog = new EventLog();
			_repository = new AccountRepository(_eventLog);
		}

		[Fact]
		public void ZeroBalanceTest()
		{
			var aAccount = _repository.GetAccount();

			Assert.Equal(0, aAccount.Balance);
		}

		[Fact]
		public void DepositTest()
		{
			var aAccount = _repository.GetAccount();
			aAccount.Deposit(1);

			Assert.Equal(1, aAccount.Balance);
		}

		[Fact]
		public void WithdrawalTest()
		{
			var aAccount = _repository.GetAccount();
			aAccount.Deposit(1);
			aAccount.Withdrawal(1);

			Assert.Equal(0, aAccount.Balance);
		}

		[Fact]
		public void WithdrawalExceptionTest()
		{
			var aAccount = _repository.GetAccount();

			Assert.Throws<WithdrawalException>(() => aAccount.Withdrawal(1));
		}

		[Fact]
		public void EventLogTest()
		{
			var aAccount = _repository.GetAccount();

			var aBalance = aAccount.Balance;

			Assert.Equal(1, _eventLog.Events.Count);
		}
	}
}