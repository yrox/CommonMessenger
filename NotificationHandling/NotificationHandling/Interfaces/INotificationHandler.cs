namespace NotificationHandling.Interfaces
{
    public interface INotificationHandler
    {
        IBusinessNotificationHandler BusinessNotificationHandler { get; }
        IUserNotificationHandler UserNotificationHandler { get; }
    }
}
