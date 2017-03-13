using Dialog.Business.Accounts;
using Dialog.Business.DTO;
using Dialog.Busness.Notifications.Interfaces;

namespace Dialog.Busness.Notifications.Handlers
{
    public class BusinessNotificationHadler : IBusinessNotificationHandler
    {
        private readonly AccountsManager _accountsManager;

        
        public BusinessNotificationHadler(AccountsManager manager, string userName)
        {
            _accountsManager = manager;
            UserName = userName;
        }

        public string UserName { get; }

        public void SendMessage(MessageDto message)
        {
            _accountsManager.SendMessage(message);
        }

        public void SendMessage(MessageDto message, string captcha, long sid)
        {
            _accountsManager.SendMessage(message, captcha, sid);
        }
    }
}
