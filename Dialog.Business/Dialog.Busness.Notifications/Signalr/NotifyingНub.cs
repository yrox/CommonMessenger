using Dialog.Business.DTO;
using Microsoft.AspNet.SignalR;

namespace Dialog.Busness.Notifications.Signalr
{
    public class NotifyingНub : Hub
    {
        public void MessageRecived(MessageDTO message)
        {
            Clients.All.MessageRecived(message);
        }
    }
}