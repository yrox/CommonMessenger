using Microsoft.Owin;
using NotificationHandling.Signalr;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NotificationHandling.Signalr
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
