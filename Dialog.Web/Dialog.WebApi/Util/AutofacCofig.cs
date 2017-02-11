using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Dialog.Services.Services;

namespace WebApi.Util
{
    public class AutofacCofig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AccountsService>().AsImplementedInterfaces();
            builder.RegisterType<MessagesService>().AsImplementedInterfaces();
            builder.RegisterType<ContactsService>().AsImplementedInterfaces();
            builder.RegisterType<MetaContactsService>().AsImplementedInterfaces();

            //builder.Register(x => new MapperConfiguration(cfg => cfg.AddProfile(typeof(MapProfile))));
            //builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

            return builder.Build();
        }
    }
}