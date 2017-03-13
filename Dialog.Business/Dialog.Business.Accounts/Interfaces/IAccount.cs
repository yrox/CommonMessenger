using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Accounts.Interfaces
{
    public interface IAccount
    {
        void AuthorizeFromToken();
        void Authorize(string code);
        void Authorize(string captcha, long sid);

        IEnumerable<ContactDto> GetAllContacts();

        void SendMessage(MessageDto message);
        void SendMessage(MessageDto message, string captcha, long sid);
    }
}
