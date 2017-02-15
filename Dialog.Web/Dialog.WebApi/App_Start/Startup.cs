using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Olga.Identity;
using Olga.Identity.EntityFramework;
using Olga.Identity.Managers;
using Owin;

namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            app.UseAutofacMiddleware(container);

            //app.CreatePerOwinContext(() => AppDbContext.Create("Dialog"));
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,//"ApplicationCookie",
                LoginPath = new PathString("/Account/Login")
            });

        }
    }
}