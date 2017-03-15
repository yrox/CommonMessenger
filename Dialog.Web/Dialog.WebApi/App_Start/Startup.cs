using System;
using Autofac;
using Dialog.WebApi.Auth;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Olga.Identity.EntityFramework;
using Olga.Identity.Managers;
using Olga.Identity.Stores;
using Owin;

namespace Dialog.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            app.UseAutofacMiddleware(container);

            app.CreatePerOwinContext(() => AppDbContext.Create("Dialog"));
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                Provider = new AuthorizationServerProvider(new AppUserManager(new AppUserStore(AppDbContext.Create("Dialog"))))
            };
            
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}