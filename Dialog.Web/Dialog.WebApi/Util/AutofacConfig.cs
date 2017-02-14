using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Dialog.Services.Util;

namespace WebApi.Util
{
    public class AutofacConfig
    {
        public static IContainer GetContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.RegisterModule(new ServiceModule());

            //builder.RegisterAssemblyModules(assemblies.ToArray());

            //Automapper Non-static configuration
            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile)).As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceMapProfile>();
                cfg.AddProfile<WebMapProfile>();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}