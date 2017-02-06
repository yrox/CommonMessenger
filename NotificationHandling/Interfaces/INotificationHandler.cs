using DTOs;

namespace NotificationHandling.Interfaces
{
    public interface INotificationHandler : IMessagesHandler
    {
        void AddContact(ContactDTO contact);
        void UpdateAccount(AccountDTO account);
        string ThrowCaptcha(string captchaUrl, long sid);
        string ThrowCode();
    }
}