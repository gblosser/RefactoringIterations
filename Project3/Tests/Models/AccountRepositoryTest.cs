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
		public void PassingTest()
		{
			var aAccount = _repository.GetAccount();

			Assert.Equal(0, aAccount.Balance);
		}
	}
}