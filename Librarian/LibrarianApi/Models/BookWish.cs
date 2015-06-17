using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.API.Models
{
  public class BookWish
  {
    public int Id { get; set; }

    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }
    public int BookId { get; set; }

    public string RequestedBy { get; set; }
    public DateTime RequestDate { get; set; }
    public BookWishStatus BookWishStatus { get; set; }
  }

  public enum BookWishStatus
  {
    NewRequest,
    Processed,
    Rejected,
    Available
  }
}