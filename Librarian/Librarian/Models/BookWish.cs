using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class BookWish
    {
    public int Id { get; set; }

    [DisplayName("Requested By")]
    public string RequestedBy { get; set; }

    [DisplayName("Book Title")]
    public string BookTitle { get; set; }
    }
  }