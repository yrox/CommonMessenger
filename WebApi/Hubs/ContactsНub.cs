using Microsoft.AspNet.SignalR;

namespace WebApi.Hubs
{
    public class ContactsНub : Hub
    {
        public void NewContactAdded()
        {
            Clients.All.NewContact();
        }
    }
}