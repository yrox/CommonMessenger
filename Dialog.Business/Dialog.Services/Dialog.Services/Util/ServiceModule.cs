using Autofac;
using Dialog.Data;
using Dialog.Data.Interfaces;
using Dialog.Services.Services;
using NotificationHandling.Handlers;
using NotificationHandling.Interfaces;

namespace Dialog.Services.Util
{
    //TODO pass accs to notifiers
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DialogUnitOfWork>().As<IDialogUnitOfWork>()
                .WithParameter("context", "DialogDb");

            builder.RegisterType<MetaContactsService>().AsImplementedInterfaces();
            builder.RegisterType<ContactsService>().AsImplementedInterfaces();
            builder.RegisterType<MessagesService>().AsImplementedInterfaces();
            builder.RegisterType<AccountsService>().AsImplementedInterfaces();

            builder.RegisterType<SignalrNotificationHandler>().As<INotificationHandler>();
            builder.RegisterType<SignalrUserNotificationHandler>().As<IUserNotificationHandler>();
            builder.RegisterType<BusinessNotificationHadler>().As<IBusinessNotificationHandler>();
        }
    }
}
