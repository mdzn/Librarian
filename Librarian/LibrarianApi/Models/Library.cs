using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librarian.API.Models
{
  public class Library
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public int Owner { get; set; }
  }
}