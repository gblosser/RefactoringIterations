using System.Web.Http;
using Project3.Models;

namespace Project3.Controllers
{
	public class AccountController : ApiController
	{
		private readonly IAccountRepository _repository;

		public AccountController(IAccountRepository theRepository)
		{
			_repository = theRepository;
		}


		// GET: api/Account
		public Account Get()
		{
			return _repository.GetAccount();
		}
	}
}
