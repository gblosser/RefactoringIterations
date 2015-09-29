using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using project4.Models;

namespace project4.Controllers
{
	public class BankAccountController : Controller
	{
		private readonly HttpClient _client;

		public BankAccountController(HttpClient theHttpClient)
		{
			_client = theHttpClient;
		}

		// GET: BankAccount
		public async Task<ActionResult> Index()
		{
			var aResponse = await _client.GetAsync("banking/api/account");
			var aContent = await aResponse.Content.ReadAsStringAsync();
			var aAccount = JsonConvert.DeserializeObject(aContent, typeof(BankAccount));

			return View(aAccount);
		}

		// GET: BankAccount/Details/5
		public async Task<ActionResult> Deposit()
		{
			var aResponse = await _client.GetAsync("banking/api/account");
			var aContent = await aResponse.Content.ReadAsStringAsync();
			var aAccount = JsonConvert.DeserializeObject(aContent, typeof(BankAccount));

			return View(aAccount);
		}


		[HttpPost]
		public async Task<RedirectResult> Deposit(decimal amount)
		{
			var aResponse = await _client.GetAsync($"banking/api/deposit/{amount}/");

			return new RedirectResult("Index");
		}

		public async Task<ActionResult> Withdrawal()
		{
			var aResponse = await _client.GetAsync("banking/api/account");
			var aContent = await aResponse.Content.ReadAsStringAsync();
			var aAccount = JsonConvert.DeserializeObject(aContent, typeof(BankAccount));

			return View(aAccount);
		}

		[HttpPost]
		public async Task<RedirectResult> Withdrawal(decimal amount)
		{
			var aResponse = await _client.GetAsync($"banking/api/withdrawal/{amount}/");
			if (!aResponse.IsSuccessStatusCode)
				return new RedirectResult("Withdrawal");

			return new RedirectResult("Index");
		}
	}
}
