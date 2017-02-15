using System.Web;
using Autofac;
using AutoMapper;
using Dialog.Data;
using Dialog.Data.Interfaces;
using Dialog.Services.Services;
using Dialog.Services.Util.MapProfiles;
using Microsoft.AspNet.Identity;
using NotificationHandling.Handlers;
using NotificationHandling.Interfaces;
using Olga.Identity;
using Olga.Identity.EntityFramework;
using Olga.Identity.Managers;
using Olga.Identity.Stores;

namespace Dialog.Services.Util
{
    //TODO pass accs to notifiers
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DialogUnitOfWork>().As<IDialogUnitOfWork>()
                .WithParameter("nameOrConnectionString", "Dialog");

            builder.RegisterType<MetaContactsService>().AsImplementedInterfaces();
            builder.RegisterType<ContactsService>().AsImplementedInterfaces();
            builder.RegisterType<MessagesService>().AsImplementedInterfaces();
            builder.RegisterType<AccountsService>().AsImplementedInterfaces();
            builder.RegisterType<UsersService>().AsImplementedInterfaces();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.RegisterType<AppDbContext>().AsSelf().WithParameter("connectionString", "Dialog").SingleInstance();
            builder.RegisterType<AppUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppUserStore>().As<IUserStore<AppUser, int>>();

            builder.RegisterType<SignalrNotificationHandler>().As<INotificationHandler>();
            builder.RegisterType<SignalrUserNotificationHandler>().As<IUserNotificationHandler>();
            builder.RegisterType<BusinessNotificationHadler>().As<IBusinessNotificationHandler>();

            builder.Register(x => new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(typeof(AccountProfile));
                    cfg.AddProfile(typeof(ContactProfile));
                    cfg.AddProfile(typeof(MessageProfile));
                    cfg.AddProfile(typeof(MetaContactProfile));
                }));
        }
    }
}
