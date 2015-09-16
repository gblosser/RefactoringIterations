using System.Web.Http;
using Project3.Models;

namespace Project3.Controllers
{
	public class DepositController : ApiController
	{
		private readonly IAccountRepository _repository;

		public DepositController(IAccountRepository theRepository)
		{
			_repository = theRepository;
		}

		// GET: api/Deposit/5
		public Account Get(decimal id)
		{
			var aAccount = _repository.GetAccount();
			aAccount.Deposit(id);
			return aAccount;
		}

	}
}
