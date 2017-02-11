using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Olga.Data;
using Olga.Data.Interfaces;

namespace WebApi.Util
{
    public class AutofacCofig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance().WithParameter("context", ());
            builder.Register(x => new MapperConfiguration(cfg => cfg.AddProfile(typeof(MapProfile))));
            //builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

            return builder.Build();
        }
    }
}