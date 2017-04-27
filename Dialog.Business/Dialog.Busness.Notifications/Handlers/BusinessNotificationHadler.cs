using Dialog.Business.Accounts;
using Dialog.Business.DTO;
using Dialog.Busness.Notifications.Interfaces;

namespace Dialog.Busness.Notifications.Handlers
{
    public class BusinessNotificationHadler : IBusinessNotificationHandler
    {
        private readonly AccountsGroup _accountsGroup;

        
        public BusinessNotificationHadler(AccountsGroup @group, string userName)
        {
            _accountsGroup = @group;
            UserName = userName;
        }

        public string UserName { get; }

        public void SendMessage(MessageDto message)
        {
            _accountsGroup.SendMessage(message);
        }

        public void SendMessage(MessageDto message, string captcha, long sid)
        {
            _accountsGroup.SendMessage(message, captcha, sid);
        }
    }
}
