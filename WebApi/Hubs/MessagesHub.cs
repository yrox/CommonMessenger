using Microsoft.AspNet.SignalR;

namespace WebApi.Hubs
{
    public class MessagesHub : Hub
    {
        public void MessageRecived()
        {
            Clients.All.MessageRecied();
        }
    }
}