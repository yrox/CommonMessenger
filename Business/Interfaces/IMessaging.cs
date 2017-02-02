using DTOs;

namespace Business.Interfaces
{
    public interface IMessaging
    {
        void SendMessage(MessageDTO message);
        void SendMessage(MessageDTO message, string captcha, long sid);
    }
}
