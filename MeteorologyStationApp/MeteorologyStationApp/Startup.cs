using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeteorologyStationApp.Startup))]
namespace MeteorologyStationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
