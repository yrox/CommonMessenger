using System.Collections.Generic;
using Business.Accounts;
using Business.Interfaces;
using DTOs;

namespace Business
{
    public class AccountsManager : BaseAccountEvents
    {
        private IAccount _account;
        
        private void Authorize(AccountDTO acc)
        {
            _account = new VkAccount(acc);

        }

        public AccountsManager(AccountDTO acc)
        {
            Authorize(acc);
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
