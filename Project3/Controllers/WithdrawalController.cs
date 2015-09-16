using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project3.Models;

namespace Project3.Controllers
{
	public class WithdrawalController : ApiController
	{
		private readonly IAccountRepository _repository;

		public WithdrawalController(IAccountRepository theRepository)
		{
			_repository = theRepository;
		}

		// GET: api/Deposit/5
		public Account Get(decimal id)
		{
			var aAccount = _repository.GetAccount();
			try
			{
				aAccount.Withdrawal(id);
			}
			catch (WithdrawalException ex)
			{
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
				{
					ReasonPhrase =
						$"Withdrawal amount {ex.WithdrawalAmount:C} exceeds the account balance {ex.AccountBalance:C}"
				});
			}
			
			return aAccount;
		}
	}
}
