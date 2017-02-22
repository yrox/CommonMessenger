using Autofac;
using Dialog.Business.Accounts.Util;
using Dialog.Busness.Notifications.Hubs;

namespace Dialog.Busness.Notifications.Util
{
    public class NotificationHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AcountsHandlingModule());

            builder.RegisterType<ConnectionMapping<string>>().AsSelf().SingleInstance();
            builder.RegisterType<NotificationsНub>().AsSelf();
            
        }
    }
}
