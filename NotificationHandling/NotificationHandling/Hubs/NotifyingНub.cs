using DTOs;
using Microsoft.AspNet.SignalR;

namespace NotificationHandling.Hubs
{
    public class NotifyingНub : Hub
    {
        public void MessageRecived(MessageDTO message)
        {
            Clients.All.MessageRecived(message);
        }
    }
}