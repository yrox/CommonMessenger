using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface INotificationsService
    {
        void CreateUserNotificator(string userName);

        void SendMessage(MessageDTO message, string userName);
    }
}
