using System;
using System.Collections.Generic;
using System.Net.Http;
using Dialog.Business.DTO;
using Microsoft.AspNet.SignalR.Client;

namespace Dialog.Client.Core.SignalR
{
    public class HubClient
    {
        private IHubProxy _hubProxy;
        private const string ServerUri = "";
        private HubConnection _connection;

        public async void ConnectAsync(string userName)
        {
            _connection = new HubConnection(ServerUri, new Dictionary<string, string> { { "userName", userName } });
            _connection.Closed += ConnectionClosed;
            _hubProxy = _connection.CreateHubProxy("NotificationsHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            InitializeEvets();
            try
            {
                await _connection.Start();
            }
            catch (HttpRequestException)
            {
                
                //No connection: Don't enable Send button or show chat UI
                return;
            }
        }

        private void ConnectionClosed()
        {
            //Deactivate chat UI; show login UI. 
        }

        public delegate void MessageRecived(MessageDto message);

        public event MessageRecived OnMessageRecived;

        public void MessageRecivedHandler(MessageDto mesage)
        {
            OnMessageRecived?.Invoke(mesage);
        }

        
        public delegate void ContactAdded(ContactDto contact);

        public event ContactAdded OnContactAdded;

        public void ContactAddedHandler(ContactDto contact)
        {
            OnContactAdded?.Invoke(contact);
        }


        public delegate string CaptchaNeeded(Uri captchaUrl, long sid);

        public event CaptchaNeeded OnCaptchaNeeded;

        public string CaptchaNeededHandler(Uri captchaUrl, long sid)
        {
            return OnCaptchaNeeded?.Invoke(captchaUrl, sid);
        }
        

        public delegate string CodeNeeded();

        public event CodeNeeded OnCodeNeeded;

        public string CodeNeededHandler()
        {
            return OnCodeNeeded?.Invoke();
        }


        private void InitializeEvets()
        {
            _hubProxy.On<MessageDto>("MessageRecived", message => OnMessageRecived(message));
            _hubProxy.On<ContactDto>("ContactAdded", contact => OnContactAdded(contact));
            _hubProxy.On<MessageDto>("MessageCaptchaNeeded", message => OnMessageRecived(message));
            _hubProxy.On("CodeNeeded", message => OnMessageRecived(message));
        }


    }
}
