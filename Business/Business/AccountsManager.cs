using System.Collections.Generic;
using Business.Accounts;
using Business.Interfaces;
using DTOs;

namespace Business
{
    public class AccountsManager : BaseAccountEvents
    {
        private IAccount _account;

        private void InitializeEvents()
        {
            (_account as BaseAccountEvents).OnMessageRecived += this.MessageRecivedHandler;
            (_account as BaseAccountEvents).OnAccountUpdated += this.AccountUpdatedHandler;
            (_account as BaseAccountEvents).OnCaptchaNeeded += this.CaptchaNeededHandler;
            (_account as BaseAccountEvents).OnCodeNeeded += this.CodeNeededHandler;
            (_account as BaseAccountEvents).OnContactAdded += this.ContactAddedHandler;
        }

        public void Authorize(AccountDTO acc)
        {
            _account = new VkAccount(acc);
            InitializeEvents();
            _account.Authorize("467722");
           
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
