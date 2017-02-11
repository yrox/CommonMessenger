using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dialog.AccountsHandling;
using Dialog.DTOs;
using NotificationHandling.Interfaces;

namespace NotificationHandling.Handlers
{
    public class SignalrNotificationHandler : INotificationHandler
    {
        public SignalrNotificationHandler()
        {
            //var account = GetAccountAsync().Result;
            var accountsManager = new AccountsManager();
            BusinessNotificationHandler = new BusinessNotificationHadler(accountsManager);
            UserNotificationHandler = new SignalrUserNotificationHandler(accountsManager);
            accountsManager.Authorize(new AccountDTO());
        }

        public IBusinessNotificationHandler BusinessNotificationHandler { get; }

        public IUserNotificationHandler UserNotificationHandler { get; }

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
    }
}
