using Dialog.Business.DTO;
using Dialog.Web.Notifications.Interfaces;

namespace Dialog.Web.Notifications.Handlers
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
