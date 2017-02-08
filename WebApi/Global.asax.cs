using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using Data;
using NotificationHandling.Handlers;
using NotificationHandling.Interfaces;
using Olga.Data;
using Olga.Data.Interfaces;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance().WithParameter("context", new Context());
            
            
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

        protected void Application_End()
        {
            
        }
    }
}
