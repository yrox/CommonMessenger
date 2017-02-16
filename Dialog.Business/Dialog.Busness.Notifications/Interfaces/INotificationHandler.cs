namespace Dialog.Busness.Notifications.Interfaces
{
    public interface INotificationHandler
    {
        IBusinessNotificationHandler BusinessNotificationHandler { get; }

        IUserNotificationHandler UserNotificationHandler { get; }
    }
}
