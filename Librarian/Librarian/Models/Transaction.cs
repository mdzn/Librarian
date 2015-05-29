using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class Transaction
    {
    public virtual LibraryBook LibraryBook { get; set; }
    public DateTime CheckOut { get; set; }
    public DateTime CheckIn { get; set; }
    public int CheckedOutBy { get; set; } // FK for Users
    }
  }