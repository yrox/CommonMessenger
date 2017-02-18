namespace Dialog.Web.Notifications.Interfaces
{
    public interface INotificationHandler
    {
        IBusinessNotificationHandler BusinessNotificationHandler { get; }

        IUserNotificationHandler UserNotificationHandler { get; }
    }
}
