using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Librarian.API.Models;
using Librarian.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Librarian.API
{
  public interface IAuthenticationRepository : IDisposable
  {
    Task<IdentityResult> RegisterUser(UserModel userModel);
    Task<IdentityUser> FindUser(string userName, string password);
    IQueryable<UserModel> GetAll();
  }
}