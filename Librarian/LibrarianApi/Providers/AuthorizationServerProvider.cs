﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Librarian.API.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;

namespace Librarian.API.Providers
{
  public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
  {
    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {

      context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

      using (AuthenticationRepository _repo = new AuthenticationRepository())
      {
        IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

        if (user == null)
        {
          context.SetError("invalid_grant", "The user name or password is incorrect.");
          return;
        }
      }

      var identity = new ClaimsIdentity(context.Options.AuthenticationType);
      identity.AddClaim(new Claim("sub", context.UserName));
      identity.AddClaim(new Claim("role", "user"));

      context.Validated(identity);
    }
  }
}