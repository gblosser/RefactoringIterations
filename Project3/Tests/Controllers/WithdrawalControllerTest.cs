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
	public class WithdrawalControllerTest
	{
		private readonly WithdrawalController _controller;

		public WithdrawalControllerTest()
		{
			var aEventLog = new EventLog();
			var aMockRepo = new Mock<IAccountRepository>();
			var aAccount = new Account(0, aEventLog);
			aAccount.Deposit(10);	// seed the account with a positive balance
			aMockRepo.Setup(aRepo => aRepo.GetAccount()).Returns(aAccount);

			/*********************************************************************************************
				build mock data for ControllerContext so that context-dependent properties can be tested 
				(headers, routing, etc...)
			*********************************************************************************************/
			var config = new HttpConfiguration();
			var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/account");
			var route = config.Routes.MapHttpRoute("DefaultApi", "api/v{version}/{controller}/{id}");
			var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "Withdrawal" } });

			/*********************************************************************************************
				build the Controller (class under test) and initialize it with the ControllerContext
			*********************************************************************************************/
			_controller = new WithdrawalController(aMockRepo.Object)
			{
				ControllerContext = new HttpControllerContext(config, routeData, request),
				Request = request
			};
			_controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
		}

		[Fact]
		public void WithdrawalTest()
		{
			var aAccount = _controller.Get(5m);

			Assert.Equal(5, aAccount.Balance);
		}

		[Fact]
		public void WithdrawalExceptionTest()
		{
			Assert.Throws<HttpResponseException>(() => _controller.Get(11m));
		}
	}
}