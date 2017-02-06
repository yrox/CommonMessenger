using System.Collections.Generic;
using Business.Accounts;
using Business.Interfaces;
using DTOs;

namespace Business
{
    public class AccountsManager : BaseAccountEvents
    {
        private IEnumerable<IAccount> _accounts;
        
        private void Authorize(IEnumerable<AccountDTO> accs)
        {
            
        }

        public AccountsManager(IEnumerable<AccountDTO> accs)
        {
            Authorize(accs);
        }
       
        public IEnumerable<ContactDTO> GetAllContacts()
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(MessageDTO message)
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(MessageDTO message, string captcha, long sid)
        {
            throw new System.NotImplementedException();
        }
    }
}
