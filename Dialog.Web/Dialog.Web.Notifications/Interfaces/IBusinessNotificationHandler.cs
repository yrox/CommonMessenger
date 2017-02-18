using Dialog.Business.DTO;

namespace Dialog.Web.Notifications.Interfaces
{
    public interface IBusinessNotificationHandler
    {
        void SendMessage(MessageDTO message);

        void SendMessage(MessageDTO message, string captcha, long sid);
    }
}
