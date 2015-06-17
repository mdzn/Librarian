using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Librarian.API.Models
{
  public class AuthenticationContext : IdentityDbContext<IdentityUser>
  {
    public AuthenticationContext()
      : base("AuthenticationContext")
    {

    }

    //public System.Data.Entity.DbSet<UserModel> UserModels { get; set; }
  }
}