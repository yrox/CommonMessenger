using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Dialog.Business.Accounts;
using Dialog.Business.DTO;
using Dialog.Busness.Notifications.Hubs;
using Dialog.Busness.Notifications.Interfaces;
using Dialog.Busness.Notifications.Util;
using Microsoft.AspNet.SignalR;

namespace Dialog.Busness.Notifications.Handlers
{
    public class SignalrUserNotificationHandler : IUserNotificationHandler
    {
        private readonly AccountsManager _accountsManager;
        private readonly ConnectionMapping<string> _connections;
        private readonly IHubContext _hubContext;
        private readonly HttpClient _httpClient;

        public SignalrUserNotificationHandler(AccountsManager manager, ConnectionMapping<string> connections, string userName)
        {
            UserName = userName;
            _accountsManager = manager;
            _connections = connections;
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsНub>();
            InitializeAccountsManagerEvents();

            //TODO change base address
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:53473/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string UserName { get; }

        public void SendMessage(MessageDto message)
        {
            _httpClient.PostAsJsonAsync("api/message", message);
            foreach (var connection in _connections.GetConnections(UserName))
            {
                _hubContext.Clients.Client(connection).MessageRecived(message);
            }
        }

        public void AddContact(ContactDto contact)
        {
            _httpClient.PostAsJsonAsync("api/contact", contact);
        }

        public string ThrowCaptcha(Uri captchaUrl, long sid)
        {
            var result = string.Empty;
            foreach (var connection in _connections.GetConnections(UserName))
            {
                result = _hubContext.Clients.Client(connection).CaptchaNeeded(captchaUrl, sid);
            }
            return result;
        }

        public string ThrowCode()
        {
            var result = string.Empty;
            foreach (var connection in _connections.GetConnections(UserName))
            {
                result = _hubContext.Clients.Client(connection).CodeNeeded();
            }
            return result;
        }

        public void UpdateAccount(AccountDto account)
        {
            _httpClient.PutAsJsonAsync($"api/account/{account.Id}", account);
        }

        private void InitializeAccountsManagerEvents()
        {
            _accountsManager.OnMessageRecived += SendMessage;
            _accountsManager.OnAccountUpdated += UpdateAccount;
            _accountsManager.OnCaptchaNeeded += ThrowCaptcha;
            _accountsManager.OnCodeNeeded += ThrowCode;
            _accountsManager.OnContactAdded += AddContact;
        }
    }
}
