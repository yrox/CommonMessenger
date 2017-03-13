using Dialog.Business.DTO;

namespace Dialog.Busness.Notifications.Interfaces
{
    public interface IBusinessNotificationHandler
    {
        void SendMessage(MessageDto message);

        void SendMessage(MessageDto message, string captcha, long sid);
    }
}
