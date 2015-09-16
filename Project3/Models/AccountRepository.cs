namespace Project3.Models
{
	public class AccountRepository : IAccountRepository
	{
		private readonly Account _account;

		public AccountRepository(EventLog theEventLog)
		{
			_account = new Account(5, theEventLog);
		}

		public Account GetAccount()
		{
			return _account;
		}
	}
}