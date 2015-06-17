using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Librarian.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Librarian.API.Repositories
{
  public class AuthenticationRepository : IAuthenticationRepository
  {
    private AuthenticationContext _authContext;
    private UserManager<IdentityUser> _userManager;

    public AuthenticationRepository()
    {
      _authContext = new AuthenticationContext();
      _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authContext));
    }

    public async Task<IdentityResult> RegisterUser(UserModel userModel)
    {
      var user = new IdentityUser
      {
        UserName = userModel.UserName
      };

      var result = await _userManager.CreateAsync(user, userModel.Password);
      return result;
    }

    public async Task<IdentityUser> FindUser(string userName, string password)
    {
      var user = await _userManager.FindAsync(userName, password);
      return user;
    }

    public IQueryable<UserModel> GetAll()
    {
      //new [] {new UserModel{ UserName = "Test Hardcoded", Password = "Pass123", ConfirmPassword = "Pass123"}}
      return null;
    }

    public void Dispose()
    {
      _authContext.Dispose();
      _userManager.Dispose();
    }
  }
}