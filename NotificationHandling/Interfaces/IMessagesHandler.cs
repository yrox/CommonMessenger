using DTOs;

namespace NotificationHandling.Interfaces
{
    public interface IMessagesHandler
    {
        void SendMessage(MessageDTO message);
        void SendMessage(MessageDTO message, string captcha, long sid);
    }
}
