using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.Entities
{
  public class LibraryBook
  {
    public int Id { get; set; }
    public bool IsAvailable { get; set; }

    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }
    public int BookId { get; set; }

    [ForeignKey("LibraryId")]
    public virtual Library Library { get; set; }
    public int LibraryId { get; set; }

    public DateTime DateAdded { get; set; }

    [NotMapped]
    public virtual ICollection<Transaction> Transactions { get; set; }
  }
}