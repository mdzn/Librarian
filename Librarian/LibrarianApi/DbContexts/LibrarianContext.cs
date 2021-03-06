﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librarian.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Librarian.API.Models
{
  public class LibrarianContext : IdentityDbContext<IdentityUser>, ILibrarianContext
  {
    public LibrarianContext()
      : base("AuthenticationContext")
    {

    }

    public System.Data.Entity.DbSet<Book> Books { get; set; }
    public System.Data.Entity.DbSet<Author> Authors { get; set; }
    public System.Data.Entity.DbSet<BookPublisher> BookPublishers { get; set; }
    public System.Data.Entity.DbSet<Transaction> Transactions { get; set; }
    public System.Data.Entity.DbSet<LibraryBook> LibraryBooks { get; set; }
  }
}