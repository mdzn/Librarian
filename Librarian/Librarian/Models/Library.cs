using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Models
  {
  public class Library
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; } // FK for user
    public bool IsPublic { get; set; }

   // [ForeignKey("UserId")]
    //public virtual ApplicationUser ApplicationUser { get; set; }
    }
  }