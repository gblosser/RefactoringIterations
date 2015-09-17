using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Project3.Controllers;
using Xunit;
using Moq;
using Project3.Models;

namespace Project3.Tests.Controllers
{
	public class AccountControllerTest
	{
		private readonly AccountController _controller;

		public AccountControllerTest()
		{
			var aEventLog = new EventLog();
			var aMockRepo = new Mock<IAccountRepository>();
			aMockRepo.Setup(aRepo => aRepo.GetAccount()).Returns(new Account(0, aEventLog));

			/*********************************************************************************************
				build mock data for ControllerContext so that context-dependent properties can be tested 
				(headers, routing, etc...)
			*********************************************************************************************/
			var config = new HttpConfiguration();
			var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/account");
			var route = config.Routes.MapHttpRoute("DefaultApi", "api/v{version}/{controller}/{id}");
			var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "Account" } });

			/*********************************************************************************************
				build the Controller (class under test) and initialize it with the ControllerContext
			*********************************************************************************************/
			_controller = new AccountController(aMockRepo.Object)
			{
				ControllerContext = new HttpControllerContext(config, routeData, request),
				Request = request
			};
			_controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
		}

		[Fact]
		public void AccountBalanceZeroTest()
		{
			var aAccount = _controller.Get();
			Assert.Equal(0, aAccount.Balance);
		}
	}
}