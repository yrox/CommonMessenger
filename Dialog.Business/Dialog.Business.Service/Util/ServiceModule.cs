using System.Web;
using Autofac;
using AutoMapper;
using Dialog.Business.Service.Services;
using Dialog.Business.Service.Util.MapProfiles;
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
            
            builder.RegisterType<MetaContactsService>().AsImplementedInterfaces();
            builder.RegisterType<ContactsService>().AsImplementedInterfaces();
            builder.RegisterType<MessagesService>().AsImplementedInterfaces();
            builder.RegisterType<AccountsService>().AsImplementedInterfaces();
            builder.RegisterType<NotifiationsService>().AsImplementedInterfaces().SingleInstance();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            builder.Register(x => new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(typeof(AccountProfile));
                    cfg.AddProfile(typeof(ContactProfile));
                    cfg.AddProfile(typeof(MessageProfile));
                    cfg.AddProfile(typeof(MetaContactProfile));
                    cfg.AddProfile(typeof(UserProfile));
                }));

            Mapper.Initialize(cfg => {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<ContactProfile>();
                cfg.AddProfile<MessageProfile>();
                cfg.AddProfile<MetaContactProfile>();
                cfg.AddProfile<UserProfile>();
            });


            builder.RegisterInstance(Mapper.Configuration)
                .As<IConfigurationProvider>()
                .SingleInstance();

            builder.Register(context =>
            {
                var provider = context.Resolve<IConfigurationProvider>();
                var mapper = new Mapper(provider);
                return mapper;
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
