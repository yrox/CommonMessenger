using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Module = Autofac.Module;

namespace WebApi.Util
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<AccountsService>().AsImplementedInterfaces();
            //builder.RegisterType<MessagesService>().AsImplementedInterfaces();
            //builder.RegisterType<ContactsService>().AsImplementedInterfaces();
            //builder.RegisterType<MetaContactsService>().AsImplementedInterfaces();

            builder.Register(x => new MapperConfiguration(cfg => cfg.AddProfile(typeof(MapProfile))));
            //builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
    }
}