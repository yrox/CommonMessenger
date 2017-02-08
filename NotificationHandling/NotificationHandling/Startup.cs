using Microsoft.Owin;
using NotificationHandling;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NotificationHandling
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
