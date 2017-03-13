using System;
using Dialog.Business.DTO;

namespace Dialog.Busness.Notifications.Interfaces
{
    public interface IUserNotificationHandler
    {
        void SendMessage(MessageDto message);

        void AddContact(ContactDto contact);

        void UpdateAccount(AccountDto account);

        string ThrowCaptcha(Uri captchaUrl, long sid);

        string ThrowCode();
    }
}