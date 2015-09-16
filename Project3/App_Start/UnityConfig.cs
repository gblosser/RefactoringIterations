using Microsoft.Practices.Unity;
using System.Web.Http;
using Project3.Models;
using Unity.WebApi;

namespace Project3
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IAccountRepository, AccountRepository>(new ContainerControlledLifetimeManager());
			container.RegisterInstance(new EventLog(), new ContainerControlledLifetimeManager());

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}