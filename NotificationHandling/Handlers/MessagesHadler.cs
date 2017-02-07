using Business;
using DTOs;
using NotificationHandling.Interfaces;

namespace NotificationHandling.Handlers
{
    public class MessagesHadler : IMessagesHandler
    {
        private readonly AccountsManager _accountsManager;

        public MessagesHadler(AccountsManager manager)
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
