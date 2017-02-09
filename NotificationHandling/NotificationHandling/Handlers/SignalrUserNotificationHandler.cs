using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Business;
using Business.Accounts;
using DTOs;
using Microsoft.AspNet.SignalR;
using NotificationHandling.Hubs;
using NotificationHandling.Interfaces;

namespace NotificationHandling.Handlers
{
    public class SignalrUserNotificationHandler : IUserNotificationHandler
    {
        private readonly IHubContext _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotifyingНub>();
        private readonly AccountsManager _accountsManager;
        private readonly HttpClient _httpClient;

        private void InitializeAccountsManagerEvents()
        {
            _accountsManager.OnMessageRecived += SendMessage;
            _accountsManager.OnAccountUpdated += UpdateAccount;
            _accountsManager.OnCaptchaNeeded += ThrowCaptcha;
            _accountsManager.OnCodeNeeded += ThrowCode;
            _accountsManager.OnContactAdded += AddContact;
        }


        public SignalrUserNotificationHandler(AccountsManager manager)
        {
            _accountsManager = manager;
            InitializeAccountsManagerEvents();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:53473/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public void SendMessage(MessageDTO message)
        {
            _httpClient.PostAsJsonAsync("api/messages", message);
            _hubContext.Clients.All.MessageRecived(message);
        }

        public void AddContact(ContactDTO contact)
        {
            _httpClient.PostAsJsonAsync("api/contacts", contact);
        }

        public string ThrowCaptcha(Uri captchaUrl, long sid)
        {
            return _hubContext.Clients.All.CaptchaNeeded(captchaUrl);
        }

        public string ThrowCode()
        {
            return _hubContext.Clients.All.CodeNeeded();
        }

        public void UpdateAccount(AccountDTO account)
        {
            _httpClient.PutAsJsonAsync($"api/accounts/{account.Id}", account);
        }

        
    }
}
