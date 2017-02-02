using System;
using Microsoft.AspNet.SignalR;
using NUnit.Framework;
using WebApi.Hubs;

namespace WebApi.Test.HubsTests
{
    [TestFixture]
    public class MessagesHubTests
    {
        [Test]
        public void NewConactAdded_ShouldNotifyClient_Succeed()
        {
            var hub = new Lazy<IHubContext>(
            () => GlobalHost.ConnectionManager.GetHubContext<MessagesHub>()
        );
            hub.Value.Clients.All.NewContactAdded();
            Assert.That(hub.IsValueCreated);
        }
    }
}
