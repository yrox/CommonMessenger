using System;
using DTOs;

namespace NotificationHandling.Interfaces
{
    public interface INotificationHandler
    {
        void SendMessage(MessageDTO message);
        void AddContact(ContactDTO contact);
        void UpdateAccount(AccountDTO account);
        string ThrowCaptcha(Uri captchaUrl, long sid);
        string ThrowCode();
    }
}