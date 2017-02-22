using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Dialog.Business.Service.Util;
using WebApi.Controllers;

namespace WebApi.Util
{
    public class AutofacConfig
    {
        public static IContainer GetContainerBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            //builder.RegisterAssemblyModules(assemblies.ToArray());

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.RegisterModule(new ServiceModule());

            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile)).As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebMapProfile>();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>().InstancePerLifetimeScope();
            
            return builder.Build();
        }
    }
}