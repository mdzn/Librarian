using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class Review
    {
    public int Id { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    public int BookId { get; set; }
    public string UserId { get; set; } //use the email value

    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }
    }
  }