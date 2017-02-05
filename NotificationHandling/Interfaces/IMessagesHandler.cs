using DTOs;

namespace NotificationHandling.Interfaces
{
    public interface IMessagesHandler
    {
        void SendMessage(MessageDTO message);
    }
}
