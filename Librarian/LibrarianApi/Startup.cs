using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Librarian.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Librarian.API.Startup))] //tell owin which class to start
namespace Librarian.API
{
  public class Startup
  {
    /// <summary>
    /// Called by the host at run-time
    /// </summary>
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();

      ConfigureOAuth(app);

      WebApiConfig.Register(config);
      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
      app.UseWebApi(config);
    }

    public void ConfigureOAuth(IAppBuilder app)
    {
      var oAuthServerOptions = new OAuthAuthorizationServerOptions()
      {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = new AuthorizationServerProvider()
      };

      // Token Generation
      app.UseOAuthAuthorizationServer(oAuthServerOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
    }
  }
}