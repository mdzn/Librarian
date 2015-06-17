using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librarian.API.Models
{
  public interface ILibrarianContext
  {
    System.Data.Entity.DbSet<Book> Books { get; set; }
    System.Data.Entity.DbSet<Author> Authors { get; set; }
    System.Data.Entity.DbSet<BookPublisher> BookPublishers { get; set; }
  }
}