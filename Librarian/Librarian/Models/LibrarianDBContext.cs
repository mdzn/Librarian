using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class LibrarianDBContext : DbContext
    {
    public DbSet<Book> Books { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<LibraryBook> LibraryBooks { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<BookWish> BookWishes { get; set; }

    }
  }