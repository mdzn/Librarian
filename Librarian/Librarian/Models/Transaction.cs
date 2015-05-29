using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Models
  {
  public class Transaction
    {
    public int Id { get; set; }

    //[ForeignKey("LibraryBookId")]
    public virtual LibraryBook LibraryBook { get; set; }
    public DateTime CheckOut { get; set; }
    public DateTime CheckIn { get; set; }
    
      //use user.email as foregin key
    public string CheckedOutBy { get; set; } // FK for Users

    //[ForeignKey("Email")]
    //public virtual ApplicationUser ApplicationUser { get; set; }

    }
  }