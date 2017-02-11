using Dialog.AccountsHandling;
using Dialog.DTOs;
using NotificationHandling.Interfaces;

namespace NotificationHandling.Handlers
{
    public class BusinessNotificationHadler : IBusinessNotificationHandler
    {
        private readonly AccountsManager _accountsManager;

        public BusinessNotificationHadler(AccountsManager manager)
        {
            _accountsManager = manager;
        }

        public void SendMessage(MessageDTO message)
        {
            _accountsManager.SendMessage(message);
        }

        public void SendMessage(MessageDTO message, string captcha, long sid)
        {
            _accountsManager.SendMessage(message, captcha, sid);
        }
    }
}
