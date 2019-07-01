using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FCC_ClientApp.Startup))]
namespace FCC_ClientApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
