using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.Entities
{
  public class Library
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public int Owner { get; set; }

    [NotMapped] //todo remove this later -- added just for compatibility
    public virtual string UserId { get; set; }
  }
}