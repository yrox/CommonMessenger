using Dialog.DTOs;
using Microsoft.AspNet.SignalR;

namespace NotificationHandling.Signalr
{
    public class NotifyingНub : Hub
    {
        public void MessageRecived(MessageDTO message)
        {
            Clients.All.MessageRecived(message);
        }
    }
}