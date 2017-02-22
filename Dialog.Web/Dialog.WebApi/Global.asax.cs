using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;
using WebApi.Util;

namespace WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(RoutesConfig.Register);

            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(AutofacConfig.GetContainerBuilder());
        }
    }
}