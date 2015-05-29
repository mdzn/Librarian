using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class LibraryBook
    {
    public int Id { get; set; }
    public int LibraryId { get; set; }
    public int BookId { get; set; }
    public DateTime CheckOut { get; set; }
    public DateTime CheckIn { get; set; }
    public int CheckedOutBy { get; set; } // FK for Users
    }
  }