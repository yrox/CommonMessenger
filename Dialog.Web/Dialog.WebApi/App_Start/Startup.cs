using System;
using System.Web;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Olga.Identity;
using Olga.Identity.EntityFramework;
using Owin;

namespace WebApi
{
    //TODO fucking middleware
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => AppDbContext.Create("NewsDbConnectionString"));
            var builder = new ContainerBuilder();
            var container = builder.Build();

            app.UseAutofacMiddleware(container);

            app.CreatePerOwinContext(() => AppDbContext.Create("Dialog"));
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")
            });

        }
    }
}