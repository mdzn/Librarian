using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Librarian.Models
  {
  public class LibraryBook
    {
    public int Id { get; set; }
    public bool IsAvailable { get; set; }
    public int BookId { get; set; }
    public int LibraryId { get; set; }

    [ForeignKey("BookId ")]
    public virtual Book Book { get; set; }

    [ForeignKey("LibraryId ")]
    public virtual Library Library { get; set; }

    [NotMapped]
    public ICollection<Transaction> Transactions { get; set; }
    }
  }