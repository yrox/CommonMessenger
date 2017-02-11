using System.Collections.Generic;
using Dialog.AccountsHandling.Accounts;
using Dialog.AccountsHandling.Interfaces;
using Dialog.DTOs;

namespace Dialog.AccountsHandling
{
    public class AccountsManager : BaseAccountEvents
    {
        private IAccount _account;

        private void InitializeEvents()
        {
            ((BaseAccountEvents) _account).OnMessageRecived += this.MessageRecivedHandler;
            ((BaseAccountEvents) _account).OnAccountUpdated += this.AccountUpdatedHandler;
            ((BaseAccountEvents) _account).OnCaptchaNeeded += this.CaptchaNeededHandler;
            ((BaseAccountEvents) _account).OnCodeNeeded += this.CodeNeededHandler;
            ((BaseAccountEvents) _account).OnContactAdded += this.ContactAddedHandler;
        }

        public void Authorize(AccountDTO acc)
        {
            _account = new VkAccount(acc);
            InitializeEvents();
            _account.Authorize("123304");
           
        }

        //public AccountsManager(AccountDTO acc)
        //{
        //    Authorize(acc);
        //}

        public IEnumerable<ContactDTO> GetAllContacts()
        {
            return _account.GetAllContacts();
        }

        public void SendMessage(MessageDTO message)
        {
            _account.SendMessage(message);
        }

        public void SendMessage(MessageDTO message, string captcha, long sid)
        {
            _account.SendMessage(message, captcha, sid);
        }
    }
}
