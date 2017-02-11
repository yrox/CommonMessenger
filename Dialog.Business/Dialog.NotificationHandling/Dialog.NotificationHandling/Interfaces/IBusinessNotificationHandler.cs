using Dialog.DTOs;

namespace NotificationHandling.Interfaces
{
    public interface IBusinessNotificationHandler
    {
        void SendMessage(MessageDTO message);

        void SendMessage(MessageDTO message, string captcha, long sid);
    }
}
