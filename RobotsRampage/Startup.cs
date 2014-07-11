using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RobotsRampage.Startup))]
namespace RobotsRampage
{
    using Microsoft.AspNet.SignalR;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR(new HubConfiguration() { EnableDetailedErrors = true });
        }
    }
}
