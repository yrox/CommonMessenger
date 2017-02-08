using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Business;
using DTOs;
using NotificationHandling.Interfaces;

namespace NotificationHandling.Handlers
{
    public class SignalrNotificationHandler : INotificationHandler
    {
        private async Task<AccountDTO> GetAccountAsync()
        {
            var result = new AccountDTO();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:53473/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync("api/account/1");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<AccountDTO>();
            }
            return result;
        }

        public SignalrNotificationHandler()
        {
            var account = GetAccountAsync().Result;
            var accountsManager = new AccountsManager(account);
            BusinessNotificationHandler = new BusinessNotificationHadler(accountsManager);
            UserNotificationHandler = new SignalrUserNotificationHandler(accountsManager);
        }

        public IBusinessNotificationHandler BusinessNotificationHandler { get; }

        public IUserNotificationHandler UserNotificationHandler { get; }
       
    }
}
