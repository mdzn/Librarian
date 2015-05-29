using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class Library
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; } // FK for user
    }
  }