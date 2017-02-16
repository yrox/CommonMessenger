using Dialog.Business.DTO;

namespace Dialog.Busness.Notifications.Interfaces
{
    public interface IBusinessNotificationHandler
    {
        void SendMessage(MessageDTO message);

        void SendMessage(MessageDTO message, string captcha, long sid);
    }
}
