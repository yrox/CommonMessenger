using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Business;
using DTOs;
using Microsoft.AspNet.SignalR;
using NotificationHandling.Hubs;
using NotificationHandling.Interfaces;

namespace NotificationHandling
{
    public class SignalrNotificationHandler : INotificationHandler
    {
        private readonly IHubContext _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotifyingНub>();
        private readonly AccountsManager _accountsManager;
        private HttpClient _httpClient;

        public SignalrNotificationHandler(AccountsManager manager)
        {
            _accountsManager = manager;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("uri");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }


        public void SendMessage(MessageDTO message)
        {
            _hubContext.Clients.All.MessageRecived(message);
        }

        public void AddContact(ContactDTO contact)
        {
            _httpClient.PostAsJsonAsync("api/contacts", contact);
        }

        public string ThrowCaptcha(string captchaUrl, long sid)
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
