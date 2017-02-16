using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.Accounts.Accounts;
using Dialog.Business.Accounts.Interfaces;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts
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

        public void Authorize(AccountDTO acc, IMapper mapper)
        {
            _account = new VkAccount(acc, mapper);
            InitializeEvents();
            _account.Authorize("123304");
           
        }

        public AccountsManager(AccountDTO acc, IMapper mapper)
        {
            Authorize(acc, mapper);
        }

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
