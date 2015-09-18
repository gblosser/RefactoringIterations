using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MV5CApplication.Startup))]
namespace MV5CApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
