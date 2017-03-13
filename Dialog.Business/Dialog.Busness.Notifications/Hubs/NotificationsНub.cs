using System;
using System.Linq;
using System.Threading.Tasks;
using Dialog.Business.DTO;
using Dialog.Busness.Notifications.Util;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Dialog.Busness.Notifications.Hubs
{
    [HubName("NotificationsHub")]
    public class NotificationsНub : Hub
    {
        public NotificationsНub(ConnectionMapping<string> connections)
        {
            _connections = connections;
        }

        private readonly ConnectionMapping<string> _connections;

        public void MessageRecived(string userName, MessageDto message)
        {
            foreach (var connection in _connections.GetConnections(userName))
            {
                Clients.Client(connection).MessageRecived(message);
            }
        }

        public void CapthaNeeded(string userName, Uri captchaUrl, long sid)
        {
            foreach (var connection in _connections.GetConnections(userName))
            {
                Clients.Client(connection).CaptchaNeeded(captchaUrl, sid);
            }
        }
        
        public void CodeNeeded(string userName)
        {
            foreach (var connection in _connections.GetConnections(userName))
            {
                Clients.Client(connection).CodeNeeded();
            }
        }

        public override Task OnConnected()
        {
            var name = Context.QueryString["userName"];

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = Context.QueryString["userName"];

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            var name = Context.QueryString["userName"];

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}