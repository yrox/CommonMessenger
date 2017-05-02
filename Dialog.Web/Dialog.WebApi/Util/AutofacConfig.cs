using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Dialog.Business.Service.Services;
using Dialog.Business.Service.Util;
using Microsoft.AspNet.Identity;
using Olga.Identity;
using Olga.Identity.EntityFramework;
using Olga.Identity.Managers;
using Olga.Identity.Stores;

namespace Dialog.WebApi.Util
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

            builder.RegisterType<NotifiationService>().AsImplementedInterfaces();

            builder.RegisterType<AppDbContext>().AsSelf().WithParameter("connectionString", "Dialog").SingleInstance();
            builder.RegisterType<AppUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppUserStore>().As<IUserStore<AppUser, int>>();

            builder.RegisterModule(new ServiceModule());

            return builder.Build();
        }
    }
}