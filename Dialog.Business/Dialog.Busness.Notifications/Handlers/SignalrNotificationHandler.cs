using Dialog.Business.Accounts;
using Dialog.Busness.Notifications.Interfaces;

namespace Dialog.Busness.Notifications.Handlers
{
    public class SignalrNotificationHandler : INotificationHandler
    {
        public SignalrNotificationHandler(AccountsManager manager)
        {
            var accountsManager = manager;
            //accountsManager.Authorize(new AccountDTO());
            BusinessNotificationHandler = new BusinessNotificationHadler(accountsManager);
            UserNotificationHandler = new SignalrUserNotificationHandler(accountsManager);
        }

        public IBusinessNotificationHandler BusinessNotificationHandler { get; }

        public IUserNotificationHandler UserNotificationHandler { get; }

        //private async Task<AccountDTO> GetAccountAsync()
        //{
        //    var result = new AccountDTO();
        //    var httpClient = new HttpClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:53473/");
        //    httpClient.DefaultRequestHeaders.Accept.Clear();
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var response = await httpClient.GetAsync("api/accounts/1");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        result = await response.Content.ReadAsAsync<AccountDTO>();
        //    }
        //    return result;
        //}
    }
}
