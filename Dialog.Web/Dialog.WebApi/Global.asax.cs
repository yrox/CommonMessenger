﻿using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApi.Util;

namespace WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(AutofacConfig.GetContainerBuilder());

            //var h = new SignalrNotificationHandler();
        }
    }
}