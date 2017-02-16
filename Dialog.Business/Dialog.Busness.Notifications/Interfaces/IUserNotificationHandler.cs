using System;
using Dialog.Business.DTO;

namespace Dialog.Busness.Notifications.Interfaces
{
    public interface IUserNotificationHandler
    {
        void SendMessage(MessageDTO message);

        void AddContact(ContactDTO contact);

        void UpdateAccount(AccountDTO account);

        string ThrowCaptcha(Uri captchaUrl, long sid);

        string ThrowCode();
    }
}