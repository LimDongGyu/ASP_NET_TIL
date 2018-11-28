using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EddyHomePage.Startup))]
namespace EddyHomePage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
