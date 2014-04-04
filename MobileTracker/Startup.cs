using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileTracker.Startup))]
namespace MobileTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
