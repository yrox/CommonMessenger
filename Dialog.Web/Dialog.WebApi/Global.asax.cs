using System.Web.Http;
using Autofac.Integration.WebApi;
using NotificationHandling.Handlers;
using WebApi.Util;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(AutofacCofig.CreateContainer());

            var h = new SignalrNotificationHandler();
        }
    }
}
