using System.Collections.Generic;
using System.Web;
using Autofac;
using AutoMapper;
using Dialog.Business.Service.Services;
using Dialog.Busness.Notifications.Util;
using Dialog.Data;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Util
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DialogUnitOfWork>().As<IDialogUnitOfWork>()
                .WithParameter("nameOrConnectionString", "Dialog");
            
            builder.RegisterType<MetaContactservice>().AsImplementedInterfaces();
            builder.RegisterType<ContactService>().AsImplementedInterfaces();
            builder.RegisterType<MessageService>().AsImplementedInterfaces();
            builder.RegisterType<AccountService>().AsImplementedInterfaces();
            builder.RegisterType<NotifiationService>().AsImplementedInterfaces().SingleInstance();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .AutoActivate()
                .SingleInstance();

            //builder.Register(x => new MapperConfiguration(
            //    cfg =>
            //    {
            //        cfg.AddProfile(typeof(AccContactProfile));
            //        cfg.AddProfile(typeof(AccMessageProfile));
            //        cfg.AddProfile(typeof(AccountProfile));
            //        cfg.AddProfile(typeof(ContactProfile));
            //        cfg.AddProfile(typeof(MessageProfile));
            //        cfg.AddProfile(typeof(MetaContactProfile));
            //        cfg.AddProfile(typeof(UserProfile));
            //    }));

            builder.RegisterModule(new NotificationHandlerModule());

        }
    }
}
