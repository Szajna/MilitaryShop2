using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MilitaryShop.WebUI.Startup))]
namespace MilitaryShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
