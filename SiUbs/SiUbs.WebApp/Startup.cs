using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiUbs.WebApp.Startup))]
namespace SiUbs.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
