using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project4.Startup))]
namespace project4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
