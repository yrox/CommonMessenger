using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.Accounts.Accounts;
using Dialog.Business.Accounts.Interfaces;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts
{
    public class AccountsManager : BaseAccountEvents
    {
        private VkAccount _account;

        private void InitializeEvents()
        {
            ((BaseAccountEvents) _account).OnMessageRecived += this.MessageRecivedHandler;
            ((BaseAccountEvents) _account).OnAccountUpdated += this.AccountUpdatedHandler;
            ((BaseAccountEvents) _account).OnCaptchaNeeded += this.CaptchaNeededHandler;
            ((BaseAccountEvents) _account).OnCodeNeeded += this.CodeNeededHandler;
            ((BaseAccountEvents) _account).OnContactAdded += this.ContactAddedHandler;
        }

        public void Authorize(AccountDto acc, IMapper mapper)
        {
            _account = new VkAccount(acc, mapper);
            InitializeEvents();
            _account.Authorize();
           // _account.StartAskingServer();
        }

        public AccountsManager(AccountDto acc, IMapper mapper)
        {
            Authorize(acc, mapper);
        }

        public IEnumerable<ContactDto> GetAllContacts()
        {
            return _account.GetAllContacts();
        }

        public void SendMessage(MessageDto message)
        {
            _account.SendMessage(message);
        }

        public void SendMessage(MessageDto message, string captcha, long sid)
        {
            _account.SendMessage(message, captcha, sid);
        }
    }
}
