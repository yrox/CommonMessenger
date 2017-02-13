using Autofac;
using Dialog.Data;
using Dialog.Data.Interfaces;
using Dialog.Services.Services;

namespace Dialog.Services.Util
{
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
        }
    }
}
