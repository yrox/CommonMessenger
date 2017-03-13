using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface INotificationsService
    {
        void CreateUserNotificator(string userName);

        void SendMessage(MessageDto message, string userName);
    }
}
