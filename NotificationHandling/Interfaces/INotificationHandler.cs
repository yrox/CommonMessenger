using DTOs;

namespace NotificationHandling.Interfaces
{
    public interface INotificationHandler : IMessagesHandler
    {
        void AddContact(ContactDTO contact);
        void UpdateAccount(AccountDTO account);
        void ThrowCaptcha(string captchaUrl, long sid);
    }
}